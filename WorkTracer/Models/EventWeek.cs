public class EventWeek
{
    private int Id {get; set;}
    private int UserId {get; set;}
    private DateOnly StartDate {get; set;}
    private DateOnly EndDate {get; set;}
    private List<PlannerEvent> PlannerEvents {get;set;}
    private List<int> ExludedRepeatingEvents {get;set;}
}