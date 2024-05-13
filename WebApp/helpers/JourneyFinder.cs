using WebApp.DTO;
using Route = WebApp.DTO.Route;

namespace WebApp.helpers;

public static class JourneyFinder
{
    public static List<Journey> FindJourneys(List<ScheduleRoute> routes, JourneySearchParams journeySearchParams)
    {
        var graph = BuildGraph(routes);
        var departureNode = graph.Nodes.FirstOrDefault(node => node.Location.Name == journeySearchParams.departure);
        var destinationNode = graph.Nodes.FirstOrDefault(node => node.Location.Name == journeySearchParams.destination);

        if (departureNode == null || destinationNode == null)
            return new List<Journey>();
        
        var journeys = new List<Journey>();
        var visited = new HashSet<Node>();
        var currentJourney = new Journey { Routes = new List<Route>(), Price = 0, Distance = 0};

        DFS(departureNode, destinationNode, journeySearchParams.departureDatetime, currentJourney, visited, journeys);

        return journeys;
    }
    
    private static void DFS(Node current, Node destination, DateTime currentTime, Journey currentJourney, HashSet<Node> visited, List<Journey> journeys)
    {
        visited.Add(current);

        if (current.Location.Name == destination.Location.Name)
        {
            journeys.Add(new Journey
            {
                Routes = new List<Route>(currentJourney.Routes),
                Price = currentJourney.Price,
                Distance = currentJourney.Distance,
                StartDatetime = currentJourney.StartDatetime,
                EndDatetime = currentTime,
            });
            visited.Remove(current);
            return;
        }

        foreach (var edge in current.Edges)
        {
            if (!visited.Contains(edge.To) && edge.Schedule.Start.Date >= currentTime)
            {
                Route route = new Route()
                {
                    From = edge.Route.From,
                    To = edge.Route.To,
                    StartDatetime = edge.Schedule.Start.Date,
                    EndDatetime = edge.Schedule.End.Date,
                    Price = edge.Schedule.Price,
                    Distance = edge.Route.Distance
                };

                currentJourney.Routes.Add(route);
                currentJourney.Price += edge.Schedule.Price;
                currentJourney.Distance += edge.Route.Distance;
                currentJourney.StartDatetime = edge.Schedule.Start.Date;

                DFS(edge.To, destination, edge.Schedule.End.Date, currentJourney, visited, journeys);

                currentJourney.Routes.Remove(route);
                currentJourney.Price -= edge.Schedule.Price;
                currentJourney.Distance -= edge.Route.Distance;
                currentJourney.StartDatetime = currentTime;
            }
        }

        visited.Remove(current);
    }

    private static Graph BuildGraph(List<ScheduleRoute> routes)
    {
        var graph = new Graph();

        foreach (var route in routes)
        {
            var fromNode = graph.GetOrCreateNode(route.From);
            var toNode = graph.GetOrCreateNode(route.To);
            for (int i = 0; i < route.Schedule.Count; i++)
            {
                var schedule = route.Schedule[i];
                fromNode.Edges.Add(new Edge(route, toNode, schedule));
            }
        }

        return graph;
    }
}