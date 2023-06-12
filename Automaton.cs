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

        public (Node newNode, bool finished, bool isComment) goToNextNode(char token, int scope, bool lineEnd)
        {
            Node? nextNode = this.currentNode.defineNextNode(token, scope);
            (Node newNode, bool finished, bool isComment) result;

            if (nextNode == null)
            {
                if (this.isCurrentNodeTheStartNode()) throw new Exception(token + " isn't a valid character");
                result = (this.currentNode, true, this.currentNode.isComment());
                this.reset();
                return result;
            } else
            {
                this.currentNode = nextNode;
                if ((nextNode.getStateType() == "line-comment" && lineEnd) || nextNode.getStateType() == "commentFinish")
                {
                    this.reset();
                }
                
                result = (this.currentNode, false, nextNode.isComment());
                Console.WriteLine(nextNode.getStateType());
                return result;
            }
        }

        public bool isCurrentNodeTheStartNode()
        {
            return this.currentNode == this.startNode;
        }

        
    }
}
