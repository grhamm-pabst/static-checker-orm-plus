﻿using System;
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
            this.links.Add(new Link(this, nodeDestination, tokens, scope));
        }

        public Node? defineNextNode (char nextToken, int nextScope)
        {
            Link? link = this.links.Find(delegate (Link link)
            {
                return link.checkValid(nextToken, nextScope);
            });

            if (link == null)
            {
                return null;
            } else
            {
                return link.getDestination();
            }
        }

        public bool isAcceptance()
        {
            return this.acceptanceState;
        }
    }
}