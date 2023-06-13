using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Static_Checker
{
    internal class Node
    {
        
        private List<Link> links = new List<Link>();
        private bool acceptanceState;
        private string state_type;

        public Node(bool acceptanceState, string state_type)
        {
            this.acceptanceState = acceptanceState;
            this.state_type = state_type;
        }

        public void addLink(Node nodeDestination, List<char> tokens, int scope)
        {
            this.links.Add(new Link(this, nodeDestination, tokens, scope, false));
        }

        public void addLink(Node nodeDestination, List<char> tokens, int scope, bool anything)
        {
            this.links.Add(new Link(this, nodeDestination, tokens, scope, anything));
        }

        public Node? defineNextNode (char nextToken, int nextScope)
        {
            Link? link = this.links.Find(delegate (Link link)
            {
                return link.checkValid(nextToken, nextScope);
            });

            if (link == null)
            {
                Link? anythingLink = this.links.Find(delegate (Link link)
                {
                    return link.checkForAnything();
                });
                if (anythingLink == null) return null;
                else return anythingLink.getDestination();
            } else
            {
                return link.getDestination();
            }
        }

        public bool isAcceptance()
        {
            return this.acceptanceState;
        }

        public string getStateType()
        {
            return this.state_type;
        }

        public bool isComment()
        {
            return this.getStateType() == "comment" || this.getStateType() == "line-comment" || this.getStateType() == "commentFinish";
        }
    }
}
