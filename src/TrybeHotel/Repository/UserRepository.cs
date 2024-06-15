using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
            var user = _context.Users.Where(u => u.Email == login.Email).FirstOrDefault();

            if (user == null)
            {
                var errorMessage = "Incorrect e-mail or password";
                throw new Exception(errorMessage);
            }

            if (user.Password != login.Password)
            {
                var errorMessage = "Incorrect e-mail or password";
                throw new Exception(errorMessage);
            }

            return new UserDto
            {
                UserId = user.UserId,
                Email = user.Email,
                Name = user.Name,
                UserType = user.UserType
            };
        }
        public UserDto Add(UserDtoInsert user)
        {
            var addedUser = _context.Users.Add(new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client"
            }).Entity;
            _context.SaveChanges();

            return new UserDto
            {
                UserId = addedUser.UserId,
                Email = addedUser.Email,
                Name = addedUser.Name,
                UserType = addedUser.UserType
            };
        }

        public UserDto? GetUserByEmail(string userEmail)
        {
            var user = _context.Users.Where(u => u.Email == userEmail).FirstOrDefault();

            if (user == null)
                return null;

            return new UserDto
            {
                UserId = user.UserId,
                Email = user.Email,
                Name = user.Name,
                UserType = user.UserType
            };
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var usersList = _context.Users
                .Select(user => new UserDto
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    Name = user.Name,
                    UserType = user.UserType
                })
                .ToList();

            return usersList;
        }

    }
}