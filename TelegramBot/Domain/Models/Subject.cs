namespace Domain;

public class Subject
{
    public string Name { get; }
    public double Grade { get; }

    public Subject(string name, double grade)
    {
        Name = name;
        Grade = grade;
    }
}