using System.Collections.Generic;
using System.Linq;

namespace RouterSample
{
    public class AllPossibilitiesRouter : IRouter
    {
        List<Node> visiting = new List<Node>();

        public List<List<string>> GetRoutes(Node node, string target)
        {
            if (node.Value == target)
            {
                visiting.Remove(node);
                return new List<List<string>> { new List<string> { node.Value } };
            }

            if (node.Nodes.Count < 1 || visiting.Any(e => e == node))
                return null;

            var result = new List<List<string>>();
            visiting.Add(node);

            foreach (var item in node.Nodes)
            {
                var routes = GetRoutes(item, target);

                if (routes != null)
                {
                    foreach (var route in routes)
                        route.Insert(0, node.Value);

                    result.AddRange(routes);
                }
            }

            visiting.Remove(node);

            if (result.Count < 1)
                return null;

            return result;
        }
    }
}
