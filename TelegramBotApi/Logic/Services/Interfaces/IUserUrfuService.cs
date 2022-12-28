namespace Logic.Services.Interfaces;

public interface IUserUrfuService
{
    Task<object> GetUserInfo();

    Task<object> GetUserSchedule();
}