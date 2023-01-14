namespace Domain;

public class UserInfo
{
    public string Email { get; }
    public string FullName { get; }
    public string AcademGroup { get; }
    public int StudentId { get; }

    public UserInfo(string email, string fullName, string academGroup, int studentId)
    {
        Email = email;
        FullName = fullName;
        AcademGroup = academGroup;
        StudentId = studentId;
    }
}