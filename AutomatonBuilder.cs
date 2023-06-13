using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker
{
    internal static class AutomatonBuilder
    {
        public static Node build()
        {
            Node startNode = new Node(false, "start");

            List<char> digits = Enumerable.Range('0', 10).Select(x => (char)x).ToList();
            List<char> alphabet = Enumerable.Range('A', 26).Select(x => (char)x)
            .Concat(Enumerable.Range('a', 26).Select(x => (char)x))
            .ToList();

            List<char> stringCharacters = alphabet.Concat(digits)
            .Concat(new[] { '$', '_', '.', ' ' })
            .ToList();

            //cons-inteiro
            Node consInteiroNode = new Node(true, "cons-inteiro");
            startNode.addLink(consInteiroNode, digits, 0);
            consInteiroNode.addLink(consInteiroNode, digits, 0);

            //cons-real
            Node consRealDotNode = new Node(false, "cons-real");
            consInteiroNode.addLink(consRealDotNode, new List<char>() { '.' }, 0);

            Node consRealDigitNode = new Node(true, "cons-real");
            consRealDotNode.addLink(consRealDigitNode, digits, 0);
            consRealDigitNode.addLink(consRealDigitNode, digits, 0);

            Node consRealExpNode = new Node(false, "cons-real");
            consRealDigitNode.addLink(consRealExpNode, new List<char>() { 'e' }, 0);
            Node consRealExpSigNode = new Node(false, "cons-real");
            consRealExpNode.addLink(consRealExpSigNode, new List<char>() { '-', '+' }, 0);
            Node consRealExpDigitNode = new Node(true, "cons-real");
            consRealExpSigNode.addLink(consRealExpDigitNode, digits, 0);
            consRealExpNode.addLink(consRealExpDigitNode, digits, 0);
            consRealExpDigitNode.addLink(consRealExpDigitNode, digits, 0);

            //division
            Node divisionNode = new Node(true, "/");
            startNode.addLink(divisionNode, new List<char>() { '/' }, 0);

            //plus
            Node plusSignNode = new Node(true, "+");
            startNode.addLink(plusSignNode, new List<char>() { '+' }, 0);

            //percent
            Node percentSignNode = new Node(true, "%");
            startNode.addLink(percentSignNode, new List<char>() { '%' }, 0);

            //open-parenthesis
            Node openParenthesisNode = new Node(true, "(");
            startNode.addLink(openParenthesisNode, new List<char>() { '(' }, 0);

            //closed-parenthesis
            Node closedParenthesisNode = new Node(true, ")");
            startNode.addLink(closedParenthesisNode, new List<char>() { ')' }, 0);

            //comma
            Node commaNode = new Node(true, ",");
            startNode.addLink(commaNode, new List<char>() { ',' }, 0);

            //double-dots
            Node doubleDotsNode = new Node(true, ":");
            startNode.addLink(doubleDotsNode, new List<char>() { ':' }, 0);
            
            //double-dots-equal
            Node doubleDotsEqualNode = new Node(true, ":=");
            doubleDotsNode.addLink(doubleDotsEqualNode, new List<char>() { '=' }, 0);

            //dot-comma
            Node dotCommaNode = new Node(true, ";");
            startNode.addLink(dotCommaNode, new List<char>() { ';' }, 0);

            //interrogation
            Node interrogationNode = new Node(true, "?");
            startNode.addLink(interrogationNode, new List<char>() { '?' }, 0);

            //open-bracket
            Node openBracketNode = new Node(true, "[");
            startNode.addLink(openBracketNode, new List<char>() { '[' }, 0);

            //closed-bracket
            Node closedBracketNode = new Node(true, "]");
            startNode.addLink(closedBracketNode, new List<char>() { ']' }, 0);

            //open-curly-braces
            Node openCurlyBraces = new Node(true, "{");
            startNode.addLink(openCurlyBraces, new List<char>() { '{' }, 0);

            //closed-curly-braces
            Node closedCurlyBraces = new Node(true, "}");
            startNode.addLink(closedCurlyBraces, new List<char>() { '}' }, 0);

            //minus
            Node minusNode = new Node(true, "-");
            startNode.addLink(minusNode, new List<char>() { '-' }, 0);

            //times
            Node timesNode = new Node(true, "*");
            startNode.addLink(timesNode, new List<char>() { '*' }, 0);

            //exclamation
            Node exclamationNode = new Node(false, "!");
            startNode.addLink(exclamationNode, new List<char>() { '!' }, 0);

            //different
            Node differentNode = new Node(true, "!=");
            exclamationNode.addLink(differentNode, new List<char>() { '=' }, 0);

            //hashtag
            Node hashtagNode = new Node(true, "#");
            startNode.addLink(hashtagNode, new List<char>() { '#' }, 0);

            //less-than
            Node lessThanNode = new Node(true, "<");
            startNode.addLink(lessThanNode, new List<char>() { '<' }, 0);

            //less-than-or-equal-to
            Node lessThanOfEqualToNode = new Node(true, "<=");
            lessThanNode.addLink(lessThanOfEqualToNode, new List<char>() { '=' }, 0);

            //equal
            Node equalNode = new Node(false, "=");
            startNode.addLink(equalNode, new List<char>() { '=' }, 0);

            //equal-equal
            Node equalEqualNode = new Node(true, "==");
            equalNode.addLink(equalEqualNode, new List<char>() { '=' }, 0);

            //more-than
            Node moreThanNode = new Node(true, ">");
            startNode.addLink(moreThanNode, new List<char>() { '>' }, 0);

            //more-than-or-equal-to
            Node moreThanOfEqualToNode = new Node(true, ">=");
            moreThanNode.addLink(moreThanOfEqualToNode, new List<char>() { '=' }, 0);

            //block comment
            Node commentNode = new Node(false, "comment");
            divisionNode.addLink(commentNode, new List<char>() { '*' }, 0);
            Node anythingNode = new Node(false, "comment");
            commentNode.addLink(anythingNode, new List<char>(), 0, true);
            anythingNode.addLink(anythingNode, new List<char>(), 0, true);
            Node possibleCloseComment = new Node(false, "comment");
            anythingNode.addLink(possibleCloseComment, new List<char>() { '*' }, 0);
            Node closeComment = new Node(false, "comment-finish");
            possibleCloseComment.addLink(closeComment, new List<char>() { '/' }, 0);
            possibleCloseComment.addLink(anythingNode, new List<char>(), 0, true);

            //line comment
            Node lineCommentNode = new Node(false, "line-comment");
            divisionNode.addLink(lineCommentNode, new List<char>() { '/' }, 0);
            lineCommentNode.addLink(lineCommentNode, new List<char>(), 0, true);

            //cons-cadeia
            Node startStringNode = new Node(false, "cons-cadeia");
            startNode.addLink(startStringNode, new List<char>() { '"' }, 0);
            Node stringContentNode = new Node(false, "cons-cadeia");
            startStringNode.addLink(stringContentNode, stringCharacters, 0);
            stringContentNode.addLink(stringContentNode, stringCharacters, 0);
            Node endStringNode = new Node(true, "cons-cadeia");
            startStringNode.addLink(endStringNode, new List<char>() { '"' }, 0);
            stringContentNode.addLink(endStringNode, new List<char>() { '"' }, 0);

            //cons-caracter
            Node startCharNode = new Node(false, "cons-caracter");
            startNode.addLink(startCharNode, new List<char>() { '\'' }, 0);
            Node contentCharNode = new Node(false, "cons-caracter");
            startCharNode.addLink(contentCharNode, alphabet, 0);
            Node endCharNode = new Node(true, "cons-caracter");
            startCharNode.addLink(endCharNode, new List<char>() { '\'' }, 0);
            contentCharNode.addLink(endCharNode, new List<char>() { '\'' }, 0);

            //variavel
            Node variableNode = new Node(true, "variavel");
            startNode.addLink(variableNode, alphabet.Concat(new List<char>() { '_' }).ToList(), 0);
            variableNode.addLink(variableNode, alphabet.Concat(digits).Concat(new List<char>() { '_' }).ToList(), 0);

            //palavra-reservada
            Node reservedWordNode = new Node(false, "palavra-reservada");
            variableNode.addLink(reservedWordNode, new List<char>() { '-' }, 0);
            Node reservedWordPostDashNode = new Node(true, "palavra-reservada");
            reservedWordNode.addLink(reservedWordPostDashNode, alphabet, 0);
            reservedWordPostDashNode.addLink(reservedWordPostDashNode, alphabet, 0);

            //nom-funcao
            Node funcNode = new Node(true, "nom-funcao");
            startNode.addLink(funcNode, alphabet, 1);
            funcNode.addLink(funcNode, alphabet.Concat(digits).ToList(), 1);

            //nom-programa
            Node progNode = new Node(true, "nom-programa");
            startNode.addLink(progNode, alphabet, 2);
            progNode.addLink(progNode, alphabet.Concat(digits).ToList(), 2);

            

            return startNode;
        }
    }
}
