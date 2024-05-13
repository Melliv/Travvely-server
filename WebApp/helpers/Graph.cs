using WebApp.DTO;

namespace WebApp.helpers;

public class Graph
{
    public List<Node> Nodes { get; set; }

    public Graph()
    {
        Nodes = new List<Node>();
    }

    public Node GetOrCreateNode(Location location)
    {
        var node = Nodes.FirstOrDefault(n => n.Location.Name == location.Name);
        if (node == null)
        {
            node = new Node(location);
            Nodes.Add(node);
        }
        return node;
    }
}
