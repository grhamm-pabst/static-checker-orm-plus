using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker.LexemeTableCollection
{
    internal class LexemeTable
    {
        private readonly List<LexemeEntry> entries = new List<LexemeEntry>();

        public LexemeTable() {
            entries = new List<LexemeEntry>();
        }

        public void push(string lexeme, int code, int symbolTableId, int line)
        {
            entries.Add(new LexemeEntry(lexeme, code, symbolTableId, line));
        }

        public LexemeEntry findByIndex(int index)
        {
            LexemeEntry entry = entries[index];
            if (entry == null)
            {
                throw new IndexOutOfRangeException();
            } else { return entry; }
        }

        public int numOfEntries() { return entries.Count; }
    }
}
