namespace User.Domain.Contracts
{
    public interface IUserService
    {
        Task<int> InsertUser(User user);

        Task<User?> UpdateUser(int id, User user);

        Task<List<User>> GetAllUser();

        Task<User?> GetUser(int id);

        Task DeleteUser(int id);

        Task<User?> SearchUser(string input);
    }
}