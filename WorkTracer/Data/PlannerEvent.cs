using EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName;

public class PlannerEvent
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<(int col, int hour)> Cells { get; set; } = new List<(int col, int hour)>();
    public string Text { get; set; }
}
