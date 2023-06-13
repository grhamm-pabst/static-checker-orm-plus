using Static_Checker;

string? path = Console.ReadLine();
SyntaxAnalyzer syntaxAnalyzer = new SyntaxAnalyzer(path);

syntaxAnalyzer.start();