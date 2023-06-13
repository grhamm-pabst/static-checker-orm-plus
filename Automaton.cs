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

        public bool isCurrentNodeTheStartNode()
        {
            return this.currentNode == this.startNode;
        }

        public Node getCurrentNode() { return this.currentNode; }
        public void setCurrentNode(Node node) { this.currentNode = node; } 

        
    }
}
