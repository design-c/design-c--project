using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Contracts.Models;

public class UserIdModel: BaseModel<int>
{
    public int UserModelId { get; set; }
    
    public UserModel User { get; set; }
}