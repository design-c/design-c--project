using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Contracts.Models;

public class UserScheduleModel: UserIdModel
{
    [Column("updatedAt")]
    public DateTime UpdatedAt { get; set; }
    [Column("calendar")]
    public string Calendar { get; set; }
}