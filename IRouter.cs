using System.Collections.Generic;

namespace RouterSample
{
    public interface IRouter
    {
        List<List<string>> GetRoutes(Node node, string target);
    }
}
