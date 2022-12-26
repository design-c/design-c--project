namespace Logic.Services.Interfaces;

public interface IUserUrfuService
{
    Task GetUserInfo();
    
    Task GetUserSchedule();
}