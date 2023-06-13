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
        private LexemeTable lexemeTable;
        private SymbolTable symbolTable;
        private LexicalAnalyzer lexicalAnalyzer;
        private FileReader fileReader;

        private (int currentScope, int counterTilReset) scopeManager = (0, 0);

        public SyntaxAnalyzer(string? path)
        {
            this.fileReader = new FileReader(path);
            this.lexemeTable = new LexemeTable();
            this.symbolTable = new SymbolTable();
            this.lexicalAnalyzer = new LexicalAnalyzer();
        }

        private void updateScope(string type)
        {
            if (type == "tipo-func")
            {
                this.scopeManager.counterTilReset = 2;
                this.scopeManager.currentScope = 1;
            }
            if (type == "programa")
            {
                this.scopeManager.counterTilReset = 1;
                this.scopeManager.currentScope = 2;
            }
        }

        public void start()
        {
            string? line;

            while ((line = this.fileReader.nextLine()) != null)
            {
                int len = line.Length;
                for (int i = 0; i < len; i++)
                {
                    lexicalAnalyzer.nextToken(line[i], this.scopeManager.currentScope, i == len - 1);

                    if (lexicalAnalyzer.getLexicalStack().Count > 0)
                    {
                        LexicalResponse response = this.lexicalAnalyzer.popFromLexicalStack();

                        if (this.scopeManager.counterTilReset > 0)
                        {
                            this.scopeManager.counterTilReset--;
                            if (this.scopeManager.counterTilReset == 0)
                            {
                                this.scopeManager.currentScope = 0;
                            }
                        }

                        updateScope(response.lexeme);
                        Console.WriteLine(response.lexeme);
                    }

                }
                lexicalAnalyzer.forceEnd();
            }

            Console.ReadLine();
            
        }
    }
}
