using WebApp.DTO;

namespace WebApp.helpers;

public class Edge
{
    public ScheduleRoute Route { get; set; }
    public Node To { get; set; }
    public RouteSchedule Schedule { get; set; }

    public Edge(ScheduleRoute route, Node to, RouteSchedule schedule)
    {
        Route = route;
        To = to;
        Schedule = schedule;
    }
}