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

        public Tuple<Node, bool> goToNextNode(char token, int scope, bool lineEnd)
        {
            Node? nextNode = this.currentNode.defineNextNode(token, scope);
            Tuple<Node, bool> result;

            if (nextNode == null)
            {
                result = new Tuple<Node, bool>(this.currentNode, true);
                this.reset();
                return result;
            } else
            {
                this.currentNode = nextNode;
                if (nextNode.getStateType() == "line-comment" && lineEnd)
                {
                    this.reset();
                }
                
                result = new Tuple<Node, bool>(this.currentNode, false);
                return result;
            }
        }

        public bool isCurrentNodeTheStartNode()
        {
            return this.currentNode == this.startNode;
        }

        
    }
}
