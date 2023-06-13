using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private LexicalResponse currentLexicalSubject = new LexicalResponse();

        private List<LexicalResponse> lexicalStack = new List<LexicalResponse>();

        public LexicalAnalyzer()
        {
            this.resetResponse();
        }

        private void resetResponse()
        {
            this.currentLexicalSubject.lengthBeforeTruncate = 0;
            this.currentLexicalSubject.lengthAfterTruncate = 0;
            this.currentLexicalSubject.isAcceptedBeforeTruncate = false;
            this.currentLexicalSubject.isAcceptedAfterTruncate = false;
            this.currentLexicalSubject.lexeme = "";
            this.currentLexicalSubject.fullLexeme = "";
        }

        public List<LexicalResponse> getLexicalStack() { return this.lexicalStack; }

        public void feedSubject(char token, bool acceptance)
        {
            if (this.currentLexicalSubject.lexeme.Length < 30)
            {
                this.currentLexicalSubject.lexeme += token;
                this.currentLexicalSubject.lengthBeforeTruncate++;
                this.currentLexicalSubject.isAcceptedBeforeTruncate = acceptance;
            }
            this.currentLexicalSubject.fullLexeme += token;
            this.currentLexicalSubject.lengthAfterTruncate++;
        }

        public void nextToken(char token, int scope, bool lineEnd)
        {
            if ((this.automaton.getCurrentNode().getStateType() == "lineComment" && lineEnd) || this.automaton.getCurrentNode().getStateType() == "commentFinish")
            {
                this.resetResponse();
                this.automaton.reset();
            }

            Node? nextNode = this.automaton.feed(token, scope);


            if (nextNode == null)
            {
                if (this.automaton.getCurrentNode().isAcceptance() && this.currentLexicalSubject.isAcceptedBeforeTruncate)
                {
                    this.currentLexicalSubject.isAcceptedAfterTruncate = true;
                    lexicalStack.Add(this.currentLexicalSubject);
                    this.resetResponse();
                }
                else
                {
                    throw new Exception(this.currentLexicalSubject.lexeme + " Lexeme was wrongly interrupted");
                }
                this.automaton.reset();
                Node? newLexemeNode = this.automaton.feed(token, scope);
                if (newLexemeNode == null)
                {
                    if (token != ' ')
                    throw new Exception(token + " is a invalid token");

                    this.automaton.reset();
                }
                else
                {
                    this.feedSubject(token, newLexemeNode.isAcceptance());
                    this.automaton.setCurrentNode(newLexemeNode);
                }

            }
            else
            {
                this.feedSubject(token, nextNode.isAcceptance());
                this.automaton.setCurrentNode(nextNode);

            }
        }

        public void forceEnd ()
        {
            lexicalStack.Add(this.currentLexicalSubject);
        }
    }
}
