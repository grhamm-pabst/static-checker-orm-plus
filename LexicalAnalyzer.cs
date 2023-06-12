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

        public (LexicalResponse res, bool finished) nextToken(char token, int scope, bool lineEnd)
        {
            (Node newNode, bool finished, bool isComment) result = automaton.goToNextNode(token, scope, lineEnd);

            if (!result.isComment)
            {
                if (this.lexicalResponse.lexeme.Length < 30)
                {
                    this.lexicalResponse.lexeme += token;
                    this.lexicalResponse.lengthBeforeTruncate = this.lexicalResponse.lexeme.Length;
                }
                else
                {
                    if(!result.newNode.isAcceptance() && this.lexicalResponse.fullLexeme.Length == 30)
                    {
                        throw new Exception("Lexeme was truncated before it was valid");
                    }
                    else
                    {
                        this.lexicalResponse.isAcceptedBeforeTruncate = true;
                    }
                }
                this.lexicalResponse.fullLexeme += token;
                this.lexicalResponse.lengthAfterTruncate = this.lexicalResponse.fullLexeme.Length;
            } else
            {
                this.resetResponse();
            }

            if (result.finished)
            {
                if (result.newNode.isAcceptance())
                {
                    this.lexicalResponse.isAcceptedAfterTruncate = true;
                } else
                {
                    this.lexicalResponse.isAcceptedAfterTruncate = false;
                }

                LexicalResponse responseCopy = this.lexicalResponse;
                this.resetResponse();

                return (responseCopy, result.finished);
            }

            return (this.lexicalResponse, result.finished);

        }
    }
}
