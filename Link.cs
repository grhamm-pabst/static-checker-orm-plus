using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Checker
{
    internal class Link
    {
        private int scope;
        private List<char> tokens;
        private Node nodeOrigin;
        private Node nodeDestination;

        public Link(Node nodeOrigin, Node nodeDestination, List<char> tokens, int scope)
        {
            this.nodeOrigin = nodeOrigin;
            this.nodeDestination = nodeDestination;
            this.tokens = tokens;
            this.scope = scope;
        }

        public bool checkValid(char token, int scope)
        {
            return this.scope == scope && tokens.Contains(token);
        }

        public Tuple<Node, Node> getNodes()
        {
            return  Tuple.Create(nodeOrigin, nodeDestination);
        }

        public Node getDestination()
        {
            return nodeDestination;
        }
    }
}
