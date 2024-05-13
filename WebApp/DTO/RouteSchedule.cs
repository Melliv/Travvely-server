namespace WebApp.DTO;

public class RouteSchedule
{
    public string Id = "";
    public double Price = 2.0;
    public ScheduleDate Start = new ();
    public ScheduleDate End = new ();
    public Company Company = new ();
}