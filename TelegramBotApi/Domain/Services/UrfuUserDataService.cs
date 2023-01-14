using Dal.Contracts.Interfaces;
using Dal.Contracts.Models;
using Logic.Models;
using Logic.Services.Interfaces;

namespace Logic.Services;

public class UrfuUserDataService: IUserDataService
{
    
    private readonly IUrfuUserServerDataService userServerDataService;
    private readonly IUserInfoRepository userInfoRepository;
    private readonly IUserRepository userRepository;

    public UrfuUserDataService(
        IUrfuUserServerDataService userServerDataService, 
        IUserInfoRepository userInfoRepository,
        IUserRepository userRepository)
    {
        this.userServerDataService = userServerDataService;
        this.userInfoRepository = userInfoRepository;
        this.userRepository = userRepository;
    }
    
    public async Task<UserInfo> GetUserInfo(string userKey)
    {
        var user = await userRepository.GetUserByKey(userKey);
        var userinfo = await userInfoRepository.FindAsync(user.Id);
        if (userinfo != null)
            return new UserInfo(userinfo.Name, userinfo.Group, userinfo.StudentCardNumber, userinfo.Email);

        var userinfoFromSever = await userServerDataService.GetUserInfo(userKey);
        await userInfoRepository.CreateAsync(new UserInfoModel
        {
            Email = userinfoFromSever.Email,
            Group = userinfoFromSever.Group,
            StudentCardNumber = userinfoFromSever.StudentCardNumber,
            Name = userinfoFromSever.Name
        });
        
        return userinfoFromSever;
    }

    public async Task<IEnumerable<UserMark>> GetUserMarks(string userKey)
    {
        return await userServerDataService.GetUserMarks(userKey);
    }
}