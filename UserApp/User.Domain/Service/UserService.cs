namespace User.Domain.Service
{
    using Contracts;

    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private DataContext _context { get; }

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> InsertUser(User user)
        {
            User? users = await _context.Users.FirstOrDefaultAsync(
                              c => c.FirstName.ToLower() == user.FirstName.ToLower() &&
                                   c.LastName.ToLower()  == user.LastName.ToLower()  &&
                                   c.Email.ToLower()     == user.Email.ToLower()
                          );

            if (users == null)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return 1;
            }

            return 0;
        }

        public async Task<User?> UpdateUser(int id, User user)
        {
            User? searchUser = await GetUser(id);

            if (searchUser != null)
            {
                searchUser.FirstName = user.FirstName;
                searchUser.LastName  = user.LastName;
                searchUser.Age       = user.Age;
                searchUser.Email     = user.Email;
                _context.Users.Update(searchUser);
                await _context.SaveChangesAsync();
                return searchUser;
            }

            return searchUser;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task DeleteUser(int id)
        {
            User? user = await GetUser(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> SearchUser(string input)
        {
            input = input.ToLower();
            return await _context.Users.FirstOrDefaultAsync(c => c.FirstName.Contains(input) || c.LastName.Contains(input));
        }
    }
}