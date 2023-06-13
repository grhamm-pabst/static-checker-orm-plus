 namespace Static_Checker.SymbolTableCollection
{
    internal class SymbolTableReportGenerator
    {
        public void GenerateReport(SymbolTable symbolTable, string outputPath)
        {
            // Lógica para gerar o relatório .TAB
            // Você pode percorrer a tabela de símbolos e criar um arquivo de texto com as informações
            // relevantes de cada entrada

            using (StreamWriter writer = new StreamWriter(outputPath))
            {

                writer.WriteLine("Código da Equipe: 05");
                writer.WriteLine("Componentes:");
                writer.WriteLine("Alisson Mascarenhas Ornelas Oliveira; alisson.oliveira@ucsal.edu.br; (71)99723-5012");
                writer.WriteLine("Beatriz Amaral Calazans Serra; beatriz.serra@ucsal.edu.br; (71)99637-1999");
                writer.WriteLine("Daniel Borges Diniz; daniel.diniz@ucsal.edu.br; (71)98605-6677");
                writer.WriteLine("Grhamm Pabst; grhamm.pabst@ucsal.edu.br; (71)99232-9683");

                writer.WriteLine();

                writer.WriteLine("RELATÓRIO DA TABELA DE SÍMBOLOS. Texto fonte analisado: Teste.231");
                
                for (int i = 0; i < symbolTable.numOfEntries();i++){
                    SymbolEntry entry = symbolTable.findByIndex(i);
                    writer.WriteLine($"Entrada: {entry.EntryNumber}, Código: {entry.Code}, Lexeme: {entry.Lexeme},");
                    writer.WriteLine($"QtdCharAntesTrunc: {entry.LengthBeforeTruncate}, QtdCharDepoisTrunc: {entry.LengthAfterTruncate},");
                    writer.WriteLine($"TipoSimb: {entry.LexemeType}, Lines: {string.Join(", ", entry.Lines)}");
                    writer.WriteLine("----------------------------------------------------------------");
                }
            }
        }
    }
}