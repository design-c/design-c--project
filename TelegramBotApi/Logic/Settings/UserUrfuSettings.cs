using Logic.Services.Interfaces;

namespace Logic.Settings;

public class UserUrfuSettings
{
    public const string UserUrfu = nameof(UserUrfu);

    public string UserInfoUri { get; set; }

    public string UserScheduleUri { get; set; }
}