using Newtonsoft.Json;
using NuGet.Protocol;
using WebApp.DTO;
using WebApp.helpers;
using Route = WebApp.DTO.Route;

namespace WebApp.Services;

public class JourneyService
{
    public List<Journey> GetJourneys(JourneySearchParams journeySearchParams)
    {
        
        Schedule schedule = GetSchedule();
        List<Journey> journeys = JourneyFinder.FindJourneys(schedule.Routes, journeySearchParams);
        return journeys;
    }

    private Schedule GetSchedule()
    {
        // TODO change to request
        using StreamReader r = new StreamReader("schedule2.json");
        string json = r.ReadToEnd();
        Schedule? schedule = JsonConvert.DeserializeObject<Schedule>(json);
        return schedule ?? throw new InvalidOperationException();
    }
}
