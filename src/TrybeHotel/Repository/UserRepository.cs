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
            var usuario = _context.Users.SingleOrDefault(u => u.Email.Equals(login.Email) && u.Password.Equals(login.Password));

            if (usuario is null)
            {
                throw new InvalidOperationException("E-mail ou senha incorretos");
            }

            return new UserDto
            {
                UserId = usuario.UserId,
                Name = usuario.Name,
                Email = usuario.Email,
                UserType = usuario.UserType
            };
        }
        public UserDto Add(UserDtoInsert user)
         {
            if (_context.Users.Any(u => u.Email.Equals(user.Email)))
            {
                throw new InvalidOperationException("O e-mail do usuário já existe");
            }

            User novoUsuario = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client"
            };

            _context.Users.Add(novoUsuario);
            _context.SaveChanges();

            return new UserDto
            {
                UserId = novoUsuario.UserId,
                Name = novoUsuario.Name,
                Email = novoUsuario.Email,
                UserType = novoUsuario.UserType
            };
        } 

        public UserDto GetUserByEmail(string userEmail)
        {
             throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _context.Users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                UserType = u.UserType
            }).ToList();
        }

    }
}