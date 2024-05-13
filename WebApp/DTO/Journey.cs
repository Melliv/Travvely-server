
namespace WebApp.DTO;

public class Journey
{
    public string Id { get; set; } = "";
    public DateTime StartDatetime { get; set; }
    public DateTime EndDatetime { get; set; }
    public double Price { get; set; }
    public double Distance { get; set; }
    public List<Route> Routes { get; set; } = [];
}