using System.Drawing;
using WorkTracer.Data; // or the namespace where EventWeek is defined

public class PlannerEvent
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public int Day {get; set;}

    public string Color { get; set; } = "#e1f5fe";
    public TimeOnly  StartTime {get; set;}
    public TimeOnly  EndTime {get; set;}
    public EventWeek EventWeek { get; set; }
    public bool IsPaid { get; set; } = true;
    private bool IsRepeating { get; set; } = false;
}