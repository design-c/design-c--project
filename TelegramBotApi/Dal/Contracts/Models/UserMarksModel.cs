using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Contracts.Models;

public class UserMarksModel: UserIdModel
{
    [Column("name")]
    public string Name { get; set; }
    [Column("point")]
    public double Point { get; set; }
    [Column("mark")]
    public string Mark { get; set; }
}