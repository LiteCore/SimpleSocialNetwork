using SimpleSocialNetwork.Server.Services.DB;
using System.Security.Cryptography;
using System.Text;

namespace SimpleSocialNetwork.Server.Services.UserManager
{
    public class UserManager
    {
        private int keySize = 32;
        private int iterations = 1000; //just for example
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        private readonly SocialNetworkDBContext _dbContext;
        private readonly UserManagerOptions _config;

        public UserManager(SocialNetworkDBContext db, UserManagerOptions value)
        {
            _dbContext = db;
            _config = value;
        }
        public User? FindUser(string username)
        {
            return _dbContext.Users.FirstOrDefault(x => x.UserName == username);
        }
        public bool VerifyPassword(User user, string password)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, user.Salt, iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, user.Password);
        }
        private byte[] HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return hash;
        }
        public async Task<User> AddUser(string userName, string password)
        {
            var hash = HashPassword(password, out var salt);
            var user = new User()
            {
                UserName = userName,
                Password = hash,
                Salt = salt
            };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
