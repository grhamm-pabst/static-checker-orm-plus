using Static_Checker.SymbolTableCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker
{
    internal class GenMockData
    {
        private Random random;
        private SymbolTable symbolTable;

        public GenMockData(SymbolTable symbolTable)
        {
            this.symbolTable = symbolTable;
        }

        public List<SymbolEntry> GenerateSymbolEntries(int count)
        {

            for (int i = 1; i <= count; i++)
            {
                symbolTable.push(
                random.Next(1000), GenerateRandomLexeme(), symbolTable.findByIndex(i).Lexeme.Length,
                random.Next(symbolTable.findByIndex(i).LengthBeforeTruncate + 1), GenerateRandomLexemeType(), i
            );
            }

            return entries;
        }

        private string GenerateRandomLexeme()
        {
            // Aqui você pode adicionar lógica personalizada para gerar lexemas simulados
            // Por simplicidade, estou apenas usando lexemas aleatórios de tamanho fixo
            int length = random.Next(3, 10); // tamanho do lexema entre 3 e 9 caracteres
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GenerateRandomLexemeType()
        {
            // Aqui você pode adicionar lógica personalizada para gerar tipos de lexemas simulados
            // Por simplicidade, estou apenas usando tipos de lexema aleatórios de uma lista fixa
            string[] lexemeTypes = { "Type1", "Type2", "Type3", "Type4", "Type5" };
            int randomIndex = random.Next(lexemeTypes.Length);
            return lexemeTypes[randomIndex];
        }

        private List<int> GenerateRandomLines()
        {
            // Aqui você pode adicionar lógica personalizada para gerar linhas simuladas
            // Por simplicidade, estou apenas gerando uma lista de 3 a 5 números de linha aleatórios
            List<int> lines = new List<int>();
            int lineCount = random.Next(3, 6); // número de linhas entre 3 e 5

            for (int i = 0; i < lineCount; i++)
            {
                int line = random.Next(1, 100); // número de linha aleatório entre 1 e 99
                lines.Add(line);
            }

            return lines;
        }
    }
}
