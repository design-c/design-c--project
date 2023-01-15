using Dal.Contracts.Interfaces;
using Dal.Contracts.Models;
using Logic.Models;
using Logic.Services.Interfaces;

namespace Logic.Services;

public class UrfuUserDataService: IUserDataService
{
    private readonly IUrfuUserServerDataService userServerDataService;
    private readonly IUserRepository userRepository;

    public UrfuUserDataService(
        IUrfuUserServerDataService userServerDataService,
        IUserRepository userRepository)
    {
        this.userServerDataService = userServerDataService;
        this.userRepository = userRepository;
    }
    
    public async Task<UserInfo> GetUserInfo(string userKey, bool needUpdate)
    {
        var user = (await userRepository.GetUserByKeyWithInfo(userKey))!;

        if (user.Info != null && !needUpdate)
            return new UserInfo(user.Info.Name, user.Info.Group, user.Info.StudentCardNumber, user.Info.Email);

        var userinfoFromSever = await userServerDataService.GetUserInfo(userKey);
        user.Info = new UserInfoModel
        {
            Email = userinfoFromSever.Email,
            Group = userinfoFromSever.Group,
            StudentCardNumber = userinfoFromSever.StudentCardNumber,
            Name = userinfoFromSever.Name,
            UserModelId = user.Id
        };
        await userRepository.UpdateAsync(user);
        
        return userinfoFromSever;
    }

    public async Task<IEnumerable<UserMark>> GetUserMarks(string userKey, bool needUpdate)
    {
        var user = (await userRepository.GetUserByKeyWithMarks(userKey))!;
        var userMarks = user.Marks!.ToArray();
        if (userMarks.Length > 0 && !needUpdate)
            return userMarks.Select(m => new UserMark(m.Name, m.Point, m.Mark));

        var userMarksFromSever = (await userServerDataService.GetUserMarks(userKey)).ToArray();
        user.Marks = userMarksFromSever.Select(m => new UserMarksModel
        {
            Name = m.Name,
            UserModelId = user.Id,
            Point = m.Point,
            Mark = m.Mark
        }).ToList();
        await userRepository.UpdateAsync(user);
        
        return userMarksFromSever;
    }
}