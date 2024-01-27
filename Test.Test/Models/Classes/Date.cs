namespace DatePrinter.Web.Models.Classes;

public class Date
{
    public Date(DateTime time, int[] hours)
    {
        Time = time;
        Hours = hours;
    }

    public int Id { get; set; }
    public int Name { get; set; }

    public DateTime Time { get; set; }
    public int[] Hours { get; set; }
    public string[] Times { get; set; }

    public string GetDate(int hour)
    {
        return DateTime.Now.AddHours(hour).ToString("d.MM").Length < 5
            ? DateTime.Now.AddHours(hour).ToString("  d.MM")
            : DateTime.Now.AddHours(hour).ToString("d.MM");
    }

    public string GetHour(int hour)
    {
        return DateTime.Now.AddHours(hour).Hour.ToString().Length < 2
            ? "  " + DateTime.Now.AddHours(hour).Hour
            : DateTime.Now.AddHours(hour).Hour.ToString();
    }
}