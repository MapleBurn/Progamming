public class PlannerEvent
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<(int col, int hour)> Cells { get; set; } = new List<(int col, int hour)>();
<<<<<<< Updated upstream
    public int Column { get; set; }
    public int StartHour { get; set; }
    public int Duration { get; set; }
=======
    public string Text { get; set; }
    public enum Type {Working, Break, Overtime, Absence} 
>>>>>>> Stashed changes
}