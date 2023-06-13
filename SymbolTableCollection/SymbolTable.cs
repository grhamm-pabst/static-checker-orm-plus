using Static_Checker.LexemeTableCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker.SymbolTableCollection
{
    internal class SymbolTable
    {
        private readonly List<SymbolEntry> entries;
        private int counter = 0;

        public SymbolTable(){
            entries = new List<SymbolEntry>();
        }

        public int push(int code, string lexeme, int lengthBeforeTruncate, int lengthAfterTruncate, string lexemeType, int line)
        {
            SymbolEntry? entry = this.checkIfExists(lexeme);
            if (entry != null)
            {
                entry.pushLine(line);
                return entry.EntryNumber;
            }
            else
            {
                int newEntryNumber = this.newEntryNumber();
                entries.Add(new SymbolEntry(newEntryNumber, code, lexeme, lengthBeforeTruncate, lengthAfterTruncate, lexemeType));
                return newEntryNumber;
            }
        }

        public SymbolEntry findByIndex(int index)
        {
            SymbolEntry entry = entries[index];
            if (entry == null)
            {
                throw new IndexOutOfRangeException();
            }
            else { return entry; }
        }

        public int numOfEntries() { return entries.Count; }

        private int newEntryNumber()
        {
            return this.counter += 1;
        }

        private SymbolEntry? checkIfExists(string lexeme)
        {
            return entries.Find(element => lexeme == element.Lexeme);
                
        }
    }
}
