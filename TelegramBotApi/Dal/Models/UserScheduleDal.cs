namespace Dal.Models;

public class UserScheduleDal: BaseModelDal<int>
{
    public DateTime UpdatedAt { get; set; }
    public string ICalendar { get; set; }
}