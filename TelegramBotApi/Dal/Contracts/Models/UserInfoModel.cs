using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Contracts.Models;

public class UserInfoModel: UserIdModel
{
    [Column("name")]
    public string Name { get; set; }
    [Column("group")]
    public string Group { get; set; }
    [Column("number")]
    public string StudentCardNumber { get; set; } 
    [Column("email")]
    public string Email { get; set; }
}