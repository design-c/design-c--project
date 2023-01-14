namespace Logic.Models;

public class UserMark
{
    public string Name { get; }

    public double Point { get; }

    public string Mark { get; }

    public UserMark(string name, double point, string mark)
    {
        Name = name;
        Point = point;
        Mark = mark;
    }
}