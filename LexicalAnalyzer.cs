using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker
{
    public struct LexicalResponse
    {
        public string lexeme;
        public string fullLexeme;
        public int lengthBeforeTruncate;
        public int lengthAfterTruncate;
        public bool isAcceptedBeforeTruncate;
        public bool isAcceptedAfterTruncate;
    }
    internal class LexicalAnalyzer
    {
        private Automaton automaton = new Automaton();

        private LexicalResponse lexicalResponse = new LexicalResponse();

        public LexicalAnalyzer()
        {
            this.resetResponse();
        }

        private void resetResponse()
        {
            this.lexicalResponse.lengthBeforeTruncate = 0;
            this.lexicalResponse.lengthAfterTruncate = 0;
            this.lexicalResponse.isAcceptedBeforeTruncate = false;
            this.lexicalResponse.isAcceptedAfterTruncate = false;
            this.lexicalResponse.lexeme = "";
            this.lexicalResponse.fullLexeme = "";
        }

        public void nextToken(char token, int scope)
        {
            Tuple<Node, bool> result = automaton.goToNextNode(token, scope);

            if (result.Item2)
            {
                if (automaton.isCurrentNodeTheStartNode()) throw new Exception(token + " isn't a valid character");
                
                if (result.Item1.isAcceptance())
                {
                    
                }
            } else
            {

            }


        }
    }
}
