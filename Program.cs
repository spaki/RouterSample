using System;

namespace RouterSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var queries = new[] { "B", "X", "C", "E" };
            var root = GenerateNodes();

            PrintResult(queries, root, new DijkstraRouter());
            PrintResult(queries, root, new AllPossibilitiesRouter());

            Console.WriteLine();
            Console.WriteLine("end...");
            Console.ReadLine();
        }

        private static void PrintResult(string[] queries, Node root, IRouter router)
        {
            foreach (var query in queries)
            {
                Console.WriteLine();
                Console.WriteLine($"route {router.GetType()} for \"{root.Value}\" to \"{query}\":");

                var routes = router.GetRoutes(root, query);

                if (routes != null)
                {
                    foreach (var route in routes)
                    {
                        var separator = string.Empty;
                        foreach (var node in route)
                        {
                            Console.Write($"{separator}{node}");
                            separator = "->";
                        }

                        Console.WriteLine();
                    }
                }
            }
        }

        static Node GenerateNodes()
        {
            var nodeA = new Node { Value = "A", Weight = 1 };
            var nodeB = new Node { Value = "B", Weight = 1 };
            var nodeC = new Node { Value = "C", Weight = 1 };
            var nodeD = new Node { Value = "D", Weight = 1 };
            var nodeE = new Node { Value = "E", Weight = 1 };
            var nodeF = new Node { Value = "F", Weight = 1 };
            var nodeG = new Node { Value = "G", Weight = 1 };
            var nodeH = new Node { Value = "H", Weight = 1 };
            var nodeI = new Node { Value = "I", Weight = 1 };
            var nodeJ = new Node { Value = "J", Weight = 1 };
            var nodeK = new Node { Value = "K", Weight = 1 };
            var nodeL = new Node { Value = "L", Weight = 1 };
            var nodeM = new Node { Value = "M", Weight = 1 };
            var nodeN = new Node { Value = "N", Weight = 1 };
            var nodeO = new Node { Value = "O", Weight = 1 };
            var nodeP = new Node { Value = "P", Weight = 1 };

            nodeA.Nodes.Add(nodeH);
            nodeA.Nodes.Add(nodeB);
            nodeA.Nodes.Add(nodeG);

            nodeB.Nodes.Add(nodeC);

            nodeC.Nodes.Add(nodeD);

            nodeD.Nodes.Add(nodeE);
            nodeD.Nodes.Add(nodeF);
            nodeD.Nodes.Add(nodeM);

            nodeG.Nodes.Add(nodeB);

            nodeH.Nodes.Add(nodeI);
            nodeH.Nodes.Add(nodeJ);

            nodeI.Nodes.Add(nodeB);

            nodeJ.Nodes.Add(nodeK);

            nodeK.Nodes.Add(nodeB);

            nodeM.Nodes.Add(nodeN);

            nodeN.Nodes.Add(nodeO);
            nodeN.Nodes.Add(nodeP);

            nodeO.Nodes.Add(nodeP);

            nodeP.Nodes.Add(nodeN);
            nodeP.Nodes.Add(nodeO);

            return nodeA;
        }

        //static Node GenerateNodes()
        //{
        //    var nodeA = new Node { Value = "A", Weight = 1 };
        //    var nodeB = new Node { Value = "B", Weight = 1 };
        //    var nodeC = new Node { Value = "C", Weight = 1 };
        //    var nodeD = new Node { Value = "D", Weight = 1 };

        //    nodeA.Nodes.Add(nodeB);
        //    nodeA.Nodes.Add(nodeD);

        //    nodeB.Nodes.Add(nodeC);

        //    nodeD.Nodes.Add(nodeC);

        //    return nodeA;
        //}

        //static Node GenerateNodes()
        //{
        //    var nodeA = new Node { Value = "A", Weight = 1 };
        //    var nodeB = new Node { Value = "B", Weight = 1 };
        //    var nodeC = new Node { Value = "C", Weight = 1 };
        //    var nodeD = new Node { Value = "D", Weight = 1 };

        //    nodeA.Nodes.Add(nodeB);
        //    nodeB.Nodes.Add(nodeC);

        //    nodeC.Nodes.Add(nodeD);

        //    nodeD.Nodes.Add(nodeC);

        //    return nodeA;
        //}
    }
}
