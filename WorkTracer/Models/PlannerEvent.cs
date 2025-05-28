using System.Drawing;
using WorkTracer.Data; // or the namespace where EventWeek is defined

public class PlannerEvent
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public string Color { get; set; } = "#e1f5fe";
    public DateTime  StartTime {get; set;}
    public DateTime  EndTime {get; set;}
    public bool IsPaid { get; set; } = true;
    
    public UserRecord Owner { get; set; }
}