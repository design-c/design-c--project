using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Contracts.Models;

public class UserScheduleModel: BaseModel<int>
{
    [Column("updatedAt")]
    public DateTime UpdatedAt { get; set; }
    [Column("calendar")]
    public string Calendar { get; set; }
}