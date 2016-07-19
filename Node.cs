using System.Collections.Generic;

namespace RouterSample
{
    public class Node
    {
        public Node()
        {
            Nodes = new List<Node>();
        }

        public string Value { get; set; }
        public int Weight { get; set; }
        public List<Node> Nodes { get; set; }
    }
}
