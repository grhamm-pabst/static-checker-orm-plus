using Static_Checker.LexemeTableCollection;
using Static_Checker.SymbolTableCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker
{
    internal class SyntaxAnalyzer
    {
        private LexemeTable lexemeTable = new LexemeTable();
        private SymbolTable symbolTable = new SymbolTable();
        private LexicalAnalyzer lexicalAnalyzer = new LexicalAnalyzer();

        private (int currentScope, int counterTilReset) scopeManager = (0, 0);

        public SyntaxAnalyzer() { }

        private void updateScope(string type)
        {
            if (type == "tipo-func")
            {
                scopeManager.counterTilReset = 2;
                scopeManager.currentScope = 1;
            }
            if (type == "programa")
            {
                scopeManager.counterTilReset = 1;
                scopeManager.currentScope = 2;
            }
        }

        public void start()
        {
            string str = "123+123.45 /* dasdasdasdas */ \"\" umavariavel tipo-var  \'a\' //dfasofgasdgas  gasdgasgasgasd ggasdgasd";
            int len = str.Length;

            for (int i = 0; i < len; i++)
            {
                lexicalAnalyzer.nextToken(str[i], 0, i == len - 1);

                if (lexicalAnalyzer.getLexicalStack().Count > 0)
                {
                    LexicalResponse response = this.lexicalAnalyzer.popFromLexicalStack();

                    updateScope(response.lexeme);

                    if (scopeManager.counterTilReset == 1)
                    {

                    }
                    
                    Console.WriteLine("!" + response.lexeme + "!" + " - " + response.lexemeType);
                }

            }

            lexicalAnalyzer.forceEnd();
        }
    }
}
