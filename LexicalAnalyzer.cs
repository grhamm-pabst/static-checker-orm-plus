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
        public string lexemeType;
    }
    internal class LexicalAnalyzer
    {
        private Automaton automaton = new Automaton();

        private LexicalResponse currentLexicalSubject = new LexicalResponse();

        private Stack<LexicalResponse> lexicalStack = new Stack<LexicalResponse>();

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
            this.currentLexicalSubject.lexemeType = "";
        }

        public Stack<LexicalResponse> getLexicalStack() { return this.lexicalStack; }

        public LexicalResponse popFromLexicalStack()
        {
            return lexicalStack.Pop();
        }

        public void feedSubject(char token, bool acceptance, string nodeType)
        {
            if (this.currentLexicalSubject.lexeme.Length < 30)
            {
                this.currentLexicalSubject.lexeme += token;
                this.currentLexicalSubject.lengthBeforeTruncate++;
                this.currentLexicalSubject.isAcceptedBeforeTruncate = acceptance;
            }
            this.currentLexicalSubject.fullLexeme += token;
            this.currentLexicalSubject.lengthAfterTruncate++;
            this.currentLexicalSubject.lexemeType = nodeType;
        }

        public void nextToken(char token, int scope, bool lineEnd)
        {
            Node? nextNode = this.automaton.feed(token, scope);

            if (nextNode == null)
            {
                if (this.automaton.getCurrentNode().isAcceptance() && this.currentLexicalSubject.isAcceptedBeforeTruncate)
                {
                    this.currentLexicalSubject.isAcceptedAfterTruncate = true;
                    lexicalStack.Push(this.currentLexicalSubject);
                    this.resetResponse();
                }
                else
                {
                    if (token != ' ')
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
                    this.feedSubject(token, newLexemeNode.isAcceptance(), newLexemeNode.getStateType());
                    this.automaton.setCurrentNode(newLexemeNode);
                }

            }
            else
            {
                this.feedSubject(token, nextNode.isAcceptance(), nextNode.getStateType());
                this.automaton.setCurrentNode(nextNode);

            }

            if ((this.automaton.getCurrentNode().getStateType() == "line-comment" && lineEnd) || this.automaton.getCurrentNode().getStateType() == "comment-finish")
            {
                this.resetResponse();
                this.automaton.reset();
            }
        }

        public void forceEnd ()
        {
            if (this.currentLexicalSubject.lexeme != "" && (this.automaton.getCurrentNode().isAcceptance() && this.currentLexicalSubject.isAcceptedBeforeTruncate))
            {
                lexicalStack.Push(this.currentLexicalSubject);
                this.currentLexicalSubject.isAcceptedAfterTruncate = true;
                this.resetResponse();
                this.automaton.reset();
            }
        }
    }
}
