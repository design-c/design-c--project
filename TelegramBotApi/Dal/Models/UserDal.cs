namespace Dal.Models;

public class UserDal: BaseModelDal<int>
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string UserKey { get; set; } 
}