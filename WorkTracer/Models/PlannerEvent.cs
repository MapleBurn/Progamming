using System.Drawing;

public class PlannerEvent
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public int Day {get; set;}

    public string Color { get; set; } = "#e1f5fe";
    public TimeOnly  StartTime {get; set;}
    public TimeOnly  EndTime {get; set;}
}