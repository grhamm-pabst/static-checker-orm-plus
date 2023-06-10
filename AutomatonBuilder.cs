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
            Node startNode = new Node(false, "");

            List<char> digits = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

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

            //block comment
            Node commentNode = new Node(false, "comment");
            divisionNode.addLink(commentNode, new List<char>() { '*' }, 0);
            Node anythingNode = new Node(false, "comment");
            commentNode.addLink(anythingNode, new List<char>(), 0, true);
            anythingNode.addLink(anythingNode, new List<char>(), 0, true);
            Node possibleCloseComment = new Node(false, "comment");
            anythingNode.addLink(possibleCloseComment, new List<char>() { '*' }, 0);
            possibleCloseComment.addLink(anythingNode, new List<char>(), 0, true);
            Node closeComment = new Node(false, "commentFinish");
            possibleCloseComment.addLink(closeComment, new List<char>() { '/' }, 0);

            //line comment
            Node lineCommentNode = new Node(false, "line-comment");
            divisionNode.addLink(lineCommentNode, new List<char>() { '/' }, 0);
            lineCommentNode.addLink(lineCommentNode, new List<char>(), 0, true);

            return startNode;
        }
    }
}
