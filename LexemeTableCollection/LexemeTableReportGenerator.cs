using Static_Checker.LexemeTableCollection;

internal static class LexemeTableReportGenerator
    {
        public static void GenerateReport(LexemeTable lexemeTable, string outputPath, string path)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine("Código da Equipe: 05");
                writer.WriteLine("Componentes:");
                writer.WriteLine("Alisson Mascarenhas Ornelas Oliveira; alisson.oliveira@ucsal.edu.br; (71)99723-5012");
                writer.WriteLine("Beatriz Amaral Calazans Serra; beatriz.serra@ucsal.edu.br; (71)99637-1999");
                writer.WriteLine("Daniel Borges Diniz; daniel.diniz@ucsal.edu.br; (71)98605-6677");
                writer.WriteLine("Grhamm Pabst; grhamm.pabst@ucsal.edu.br; (71)99232-9683");

                writer.WriteLine();

                writer.WriteLine("RELATÓRIO DA ANÁLISE LÉXICA. Texto fonte analisado: " + path);
                writer.WriteLine("----------------------------------------------------------------");
                writer.WriteLine();

                for (int i = 0; i < lexemeTable.numOfEntries();i++){
                    LexemeEntry lexemeEntry= lexemeTable.findByIndex(i);
                
                    writer.WriteLine($"Lexeme: {lexemeEntry.Lexeme}, Code: {lexemeEntry.Code}, "
                    +$"ÍndiceTabSimb: {lexemeEntry.SymbolTableId}, Linha: {lexemeEntry.Line}");
                    writer.WriteLine("----------------------------------------------------------------");
                }
            }
        }
    }