using Application.Commands.Interfaces;

namespace Application.Commands;

public class fakCommand //: ICommand
{
    public string Command => "/fak";

    public string Description => $"{Command} - fak blyat";
    
    public string Execute()
    {
        return "fak blyayyass";
    }
}