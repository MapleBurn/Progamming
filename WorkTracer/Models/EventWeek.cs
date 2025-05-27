public class EventWeek
{
    public int Id {get; set;}
    public int UserId {get; set;}
    public DateOnly StartDate {get; set;}
    public DateOnly EndDate {get; set;}
    public List<PlannerEvent> PlannerEvents {get;set;}
    public List<int> ExludedRepeatingEvents {get;set;}
}