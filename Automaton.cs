using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker
{
    internal class Automaton
    {
        private Node startNode;
        private Node currentNode;
        public Automaton()
        {
            this.startNode = AutomatonBuilder.build();
            this.currentNode = this.startNode;
        }

        public void reset()
        {
            this.currentNode = this.startNode;
        }

        public Node? feed(char token, int scope)
        {
            return this.currentNode.defineNextNode(token, scope);
        }

        public (Node newNode, bool finished, bool isComment, bool isReset) goToNextNode(char token, int scope, bool lineEnd)
        {
            Node? nextNode = this.currentNode.defineNextNode(token, scope);
            (Node newNode, bool finished, bool isComment, bool isReset) result;

            if (nextNode == null)
            {
                result = (this.currentNode, true, this.currentNode.isComment(), true);

                this.reset();

                nextNode = this.currentNode.defineNextNode(token, scope);

                if (nextNode == null) throw new Exception(token + " isn't a valid character");

                return result;
            } else
            {
                this.currentNode = nextNode;
                if ((nextNode.getStateType() == "line-comment" && lineEnd) || nextNode.getStateType() == "commentFinish")
                {
                    this.reset();
                }
                
                result = (this.currentNode, false, nextNode.isComment(), false);
                return result;
            }
        }

        public bool isCurrentNodeTheStartNode()
        {
            return this.currentNode == this.startNode;
        }

        public Node getCurrentNode() { return this.currentNode; }
        public void setCurrentNode(Node node) { this.currentNode = node; } 

        
    }
}
