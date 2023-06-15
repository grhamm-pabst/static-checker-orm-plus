using Static_Checker;
using Static_Checker.LexemeTableCollection;
using Static_Checker.SymbolTableCollection;

string? path = Console.ReadLine();

SyntaxAnalyzer syntaxAnalyzer = new SyntaxAnalyzer(path);

(SymbolTable symbolTable, LexemeTable lexemeTable) tables = syntaxAnalyzer.start();

if (path != null)
{
    LexemeTableReportGenerator.GenerateReport(tables.lexemeTable, path.Replace(".231", ".LEX"), path);
    SymbolTableReportGenerator.GenerateReport(tables.symbolTable, path.Replace(".231", ".TAB"), path);
}