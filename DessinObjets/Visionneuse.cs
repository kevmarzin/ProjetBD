using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DessinObjets
{
    /// <summary>
    /// Classe permettant de visualiser le code SQL généré avec coloration syntaxique
    /// </summary>
    public partial class Visionneuse : Form
    {
        //    List<string> sqlKeywords = new List<string>{ "ADD","EXTERNAL","PROCEDURE","ALL","FETCH","PUBLIC","ALTER","FILE","RAISERROR","AND","FILLFACTOR","READ","ANY","FOR","READTEXT","AS","FOREIGN","RECONFIGURE","ASC","FREETEXT","REFERENCES","AUTHORIZATION","FREETEXTTABLE","REPLICATION","BACKUP","FROM","RESTORE","BEGIN","FULL","RESTRICT","BETWEEN","FUNCTION","RETURN","BREAK","GOTO","REVERT","BROWSE","GRANT","REVOKE","BULK","GROUP","RIGHT","BY","HAVING","ROLLBACK","CASCADE","HOLDLOCK","ROWCOUNT","CASE","IDENTITY","ROWGUIDCOL","CHECK","IDENTITY_INSERT","RULE","CHECKPOINT","IDENTITYCOL","SAVE","CLOSE","IF","SCHEMA","CLUSTERED","IN","SECURITYAUDIT","COALESCE","INDEX","SELECT","COLLATE","INNER","SEMANTICKEYPHRASETABLE","COLUMN","INSERT","SEMANTICSIMILARITYDETAILSTABLE","COMMIT","INTERSECT","SEMANTICSIMILARITYTABLE","COMPUTE","INTO","SESSION_USER","CONSTRAINT","IS","SET","CONTAINS","JOIN","SETUSER","CONTAINSTABLE","KEY","SHUTDOWN","CONTINUE","KILL","SOME","CONVERT","LEFT","STATISTICS","CREATE","LIKE","SYSTEM_USER","CROSS","LINENO","TABLE","CURRENT","LOAD","TABLESAMPLE","CURRENT_DATE","MERGE","TEXTSIZE","CURRENT_TIME","NATIONAL","THEN","CURRENT_TIMESTAMP","NOCHECK","TO","CURRENT_USER","NONCLUSTERED","TOP","CURSOR","NOT","TRAN","DATABASE","NULL","TRANSACTION","DBCC","NULLIF","TRIGGER","DEALLOCATE","OF","TRUNCATE","DECLARE","OFF","TRY_CONVERT","DEFAULT","OFFSETS","TSEQUAL","DELETE","ON","UNION","DENY","OPEN","UNIQUE","DESC","OPENDATASOURCE","UNPIVOT","DISK","OPENQUERY","UPDATE","DISTINCT","OPENROWSET","UPDATETEXT","DISTRIBUTED","OPENXML","USE","DOUBLE","OPTION","USER","DROP","OR","VALUES","DUMP","ORDER","VARYING","ELSE","OUTER","VIEW","END","OVER","WAITFOR","ERRLVL","PERCENT","WHEN","ESCAPE","PIVOT","WHERE","EXCEPT","PLAN","WHILE","EXEC","PRECISION","WITH","EXECUTE","PRIMARY","WITHIN GROUP","EXISTS","PRINT","WRITETEXT","EXIT","PROC"};
        List<string> sqlKeywords = new List<string> { "CREATE", "TABLE", "DATABASE", "FOREIGN", "KEY", "ALTER", "REFERENCES", "IDENTITY", "ADD", "CONSTRAINT", "PRIMARY", "KEY", "NONCLUSTERED", "WITH", "CHECK" };
        List<string> sqlComplements = new List<string> { "NOT", "NULL" };
        string[] types = new string[] { "int", "nvarchar", "bit", "datetime", "smallint", "varchar" };
        string[] punctuation = new string[] { ",", ";", "(", ")" };
        string[] operators = new string[] { };
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="text">Texte à afficher</param>
        public Visionneuse(string text)
        {
            InitializeComponent();
            texte.Text = text;
            string integers = "\\b(?:[0-9]*\\.)?[0-9]+\\b";
            string Strings = "'[^']*";
            string all = "\\r|\\n|\\(|\\)|'[^']*'|\\w+|\\[max\\]|\\[min\\]|\\[avg\\]|\\[count\\]|\\|/|\\.|\\{|\\}|\\[|\\]|\\+|:-|:=|<>|[(<=)(>=)^?!,@<>_~%/=:;*'&-]{1}?|\\$|\\?}";
            string Comments = @"|/\*(?>(?:(?>[^*]+)|\*(?!/))*)\*/";// matches multiline comments
            string reg = "--|" + integers + "|" + Strings + "|" + all;
            Regex rg = new Regex(reg + Comments, RegexOptions.IgnoreCase);
            MatchCollection mc_ = rg.Matches(texte.Text);
            string[] a = rg.GetGroupNames();
            int j = 0;
            while (j < mc_.Count)
            {
                if (mc_[j].Value == "--")
                {
                    while (mc_[j].Value != "\r")
                    {
                        texte.SelectionStart = mc_[j].Index;
                        texte.SelectionLength = mc_[j].Length;
                        texte.SelectionFont = new Font("Courrier", 10, FontStyle.Italic);
                        texte.SelectionColor = CommentColor;
                        j++;
                    }
                }
                ColorSQLToken(mc_[j]);
                j++;
            }
        }
        Color StringColor = Color.Red;
        Color CommentColor = Color.Green;
        Color KeywordColor = Color.Blue;
        Color TypesColor = Color.LightBlue;
        Color IntegerColor = Color.Brown;
        private void ColorSQLToken(Match mc)
        {
            texte.SelectionStart = mc.Index;
            texte.SelectionLength = mc.Length;
            texte.SelectionFont = new Font("Courrier", 10, FontStyle.Regular);
            texte.SelectionColor = Color.Black;
            if (mc.Value.IndexOf("'") == 0)
            {
                texte.SelectionColor = StringColor;
            }
            else
            {
                switch (FindType(mc.Value))
                {
                    case TokenType.Comment:
                        texte.SelectionColor = CommentColor;
                        break;
                    case TokenType.Keyword:
                        texte.SelectionColor = KeywordColor;
                        break;
                    case TokenType.Relation:
                        //        texte.SelectionColor = UserColor;
                        texte.SelectionFont = new Font("Courrier", 10, FontStyle.Italic);
                        break;
                    case TokenType.Punctuation:
                    case TokenType.SQLComplement:
                        texte.SelectionColor = Color.LightGray; ;
                        break;
                    case TokenType.Operator:
                        texte.SelectionColor = KeywordColor;
                        break;
                    case TokenType.Type:
                        texte.SelectionColor = TypesColor;
                        break;
                    case TokenType.BracketClose:
                    case TokenType.BracketOpen:
                        texte.SelectionColor = CommentColor;
                        break;
                    case TokenType.Aggregator:
                        texte.SelectionColor = KeywordColor;
                        break;
                    case TokenType.Integer:
                    case TokenType.Decimal:
                        texte.SelectionColor = IntegerColor;
                        break;
                    default:
                        texte.SelectionColor = Color.LightSlateGray;
                        break;
                }
            }
        }
        private TokenType FindType(string token)
        {
            TokenType t = TokenType.Default;
            if (token.IndexOf("/*") == 0)
                return TokenType.Comment;
            if (token.IndexOf("'") == 0)
                return TokenType.Text;
            if (token.IndexOf("{") == 0)
                return TokenType.BracketOpen;
            if (token.IndexOf("}") == 0)
                return TokenType.BracketClose;
            if (token.IndexOf("[") == 0)
                return TokenType.Aggregator;
            if (punctuation.Contains(token))
                return TokenType.Punctuation;
            if (sqlKeywords.Contains(token.ToUpper()))
                return TokenType.Keyword;
            if (types.Contains(token))
                return TokenType.Type;
            if (sqlComplements.Contains(token.ToUpper()))
                return TokenType.SQLComplement;
            if (operators.Contains(token))
                return TokenType.Operator;
            int b;
            if (int.TryParse(token, out b))
                return TokenType.Integer;
            double a;
            if (double.TryParse(token, out a))
                return TokenType.Decimal;
            return t;
        }
    }
    enum TokenType { Comment, Type, Integer, Decimal, Aggregator, BracketOpen, BracketClose, Text, Default, Relation, Punctuation, Operator, Keyword, SQLComplement }
}
