using WebApp.DTO;

namespace WebApp.helpers;

public class Node
{
    public Location Location { get; set; }
    public List<Edge> Edges { get; set; }

    public Node(Location location)
    {
        Location = location;
        Edges = new List<Edge>();
    }
}
