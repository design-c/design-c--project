namespace Logic.Models;

public class UserInfo
{
    public string Name { get; }

    public string Group { get; }

    public string StudentCardNumber { get; }

    public string Email { get; }

    public UserInfo(string name, string group, string studentCardNumber, string email)
    {
        Name = name;
        Group = group;
        StudentCardNumber = studentCardNumber;
        Email = email;
    }
}