public class PlannerEvent
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<(int col, int hour)> Cells { get; set; } = new List<(int col, int hour)>();
}