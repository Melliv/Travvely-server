namespace WebApp.DTO;

public class ScheduleRoute
{
    public string Id = "";
    public Location From = new ();
    public Location To = new ();
    public int Distance = 10;
    public List<RouteSchedule> Schedule = [];
}