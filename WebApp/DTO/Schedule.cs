namespace WebApp.DTO;

public class Schedule
{
    public string Id = "";
    public ScheduleDate Expires = new ();
    public List<ScheduleRoute> Routes = [];
}