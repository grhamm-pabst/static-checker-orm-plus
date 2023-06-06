using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker.LexemeTableCollection
{
    internal class LexemeEntry
    {
        private readonly string lexeme;
        private readonly int code;
        private readonly int symbolTableId;
        private readonly int line;

        public LexemeEntry(string lexeme, int code, int symbolTableId, int line)
        {
            this.lexeme = lexeme;
            this.code = code;
            this.symbolTableId = symbolTableId;
            this.line = line;
        }

        public string Lexeme => lexeme;

        public int Code => code;

        public int SymbolTableId => symbolTableId;

        public int Line => line;
    }
}
