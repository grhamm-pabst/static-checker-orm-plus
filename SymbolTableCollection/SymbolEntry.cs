using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker.SymbolTableCollection
{
    internal class SymbolEntry
    {
        private readonly int entryNumber;
        private readonly int code;
        private readonly string lexeme;
        private readonly int lengthBeforeTruncate;
        private readonly int lengthAfterTruncate;
        private readonly string lexemeType;
        private readonly List<int> lines = new List<int>();

        public SymbolEntry(){
            
        }

        public SymbolEntry(int entryNumber, int code, string lexeme, int lengthBeforeTruncate, int lengthAfterTruncate, string lexemeType)
        {
            this.entryNumber = entryNumber;
            this.code = code;
            this.lexeme = lexeme;
            this.lengthBeforeTruncate = lengthBeforeTruncate;
            this.lengthAfterTruncate = lengthAfterTruncate;
            this.lexemeType = lexemeType;
        }

        public void pushLine(int line) { lines.Add(line); }

        public int EntryNumber => entryNumber;

        public int Code => code;

        public string Lexeme => lexeme;

        public int LengthBeforeTruncate => lengthBeforeTruncate;

        public int LengthAfterTruncate => lengthAfterTruncate;

        public string LexemeType => lexemeType;

        public List<int> Lines => lines;
    }
}
