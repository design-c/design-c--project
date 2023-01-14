using Dal.Contracts.Models;

namespace Dal.Contracts.Interfaces;

public interface IUserRepository: IRepository<UserModel, int>
{
}