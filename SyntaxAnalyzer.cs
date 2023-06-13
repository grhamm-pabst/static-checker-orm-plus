using Static_Checker.LexemeTableCollection;
using Static_Checker.SymbolTableCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker
{
    internal class SyntaxAnalyzer
    {
        private LexemeTable lexemeTable = new LexemeTable();
        private SymbolTable symbolTable = new SymbolTable();
        private LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer();

        public SyntaxAnalyzer() { }

        public void start()
        {
            string str = "123+ 123.45 \"ablubluble $\"";
            int len = str.Length;

            for (int i = 0; i < len; i++)
            {
                lexicalAnalyzer.nextToken(str[i], 0, i == len - 1);


            }

            lexicalAnalyzer.forceEnd();

            foreach (LexicalResponse response in lexicalAnalyzer.getLexicalStack())
            {
                Console.WriteLine("!" + response.lexeme + "!");
            }
        }
    }
}
