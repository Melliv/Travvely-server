namespace WebApp.DTO;

public class Route
{
    public string Id { get; set; } = "";
    public Location From { get; set; } = new ();
    public Location To { get; set; } = new ();
    public DateTime StartDatetime { get; set; }
    public DateTime EndDatetime { get; set; }
    public double Price { get; set; }
    public double Distance { get; set; }
}