namespace Dal.Models;

public class UserInfoDal: BaseModelDal<int>
{
    public string Name { get; set; }
    public string Group { get; set; }
    public string StudentCardNumber { get; set; } 
    public string Email { get; set; }
}