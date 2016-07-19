using System.Collections.Generic;
using System.Linq;

namespace RouterSample
{
    public class DijkstraRouter : IRouter
    {
        public List<List<string>> GetRoutes(Node node, string target)
        {
            var paths = ConvertToPath(node);
            var resultPath = CalculateShortestPathBetween(node.Value, target, paths);

            if (resultPath == null)
                return null; 

            var result = resultPath.Select(e => e.Source).ToList();
            result.Add(target);

            return new List<List<string>> { result };
        }

        private Dictionary<T, LinkedList<Path<T>>> CalculateShortestPaths<T>(T from, IEnumerable<Path<T>> paths)
        {
            if (paths.Any(p => p.Source.Equals(p.Destination)))
                return null;

            var shortestPaths = new Dictionary<T, KeyValuePair<int, LinkedList<Path<T>>>>();
            var locationsProcessed = new List<T>();

            paths.SelectMany(p => new T[] { p.Source, p.Destination }).Distinct().ToList().ForEach(s => Set(shortestPaths, s, int.MaxValue, null));
            Set(shortestPaths, from, 0, null);

            var locationCount = shortestPaths.Keys.Count;
            while (locationsProcessed.Count < locationCount)
            {
                var locationToProcess = default(T);

                foreach (var location in shortestPaths.OrderBy(p => p.Value.Key).Select(p => p.Key).ToList())
                {
                    if (!locationsProcessed.Contains(location))
                    {
                        if (shortestPaths[location].Key == int.MaxValue)
                            return shortestPaths.ToDictionary(k => k.Key, v => v.Value.Value); 

                        locationToProcess = location;
                        break;
                    }
                } 

                var selectedPaths = paths.Where(p => p.Source.Equals(locationToProcess));
                foreach (var path in selectedPaths)
                    if (shortestPaths[path.Destination].Key > path.Cost + shortestPaths[path.Source].Key)
                        Set(shortestPaths, path.Destination, path.Cost + shortestPaths[path.Source].Key, shortestPaths[path.Source].Value.Union(new Path<T>[] { path }).ToArray());

                locationsProcessed.Add(locationToProcess);
            }

            var result = shortestPaths.ToDictionary(k => k.Key, v => v.Value.Value);
            return result;
        }

        private LinkedList<Path<T>> CalculateShortestPathBetween<T>(T from, T to, IEnumerable<Path<T>> paths)
        {
            var result = CalculateShortestPaths(from, paths);

            if (result.ContainsKey(to))
                return result[to];

            return null;
        }

        private void Set<T>(Dictionary<T, KeyValuePair<int, LinkedList<Path<T>>>> dictionary, T target, int cost, params Path<T>[] paths)
        {
            var completePath = paths == null ? new LinkedList<Path<T>>() : new LinkedList<Path<T>>(paths);
            dictionary[target] = new KeyValuePair<int, LinkedList<Path<T>>>(cost, completePath);
        }

        private List<Path<string>> ConvertToPath(Node node, List<Path<string>> result = null)
        {
            if(result == null)
                result = new List<Path<string>>();

            foreach (var item in node.Nodes)
            {
                result.Add(new Path<string> { Source = node.Value, Destination = item.Value, Cost = node.Weight });

                if(!result.Any(e => e.Source == item.Value))
                    ConvertToPath(item, result);
            }

            return result;
        }
    }
}
