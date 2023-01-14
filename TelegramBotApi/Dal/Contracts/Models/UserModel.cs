using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Contracts.Models;

public class UserModel: BaseModel<int>
{
    [Column("login")]
    public string Login { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("key")]
    public string UserKey { get; set; } 
}