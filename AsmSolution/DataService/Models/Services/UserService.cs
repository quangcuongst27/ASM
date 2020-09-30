using DataService.Models.RequestModels;
using DataService.Models.Sercurity;
using DataService.Models.ServiceModels;
using DataService.Models.UnitOfWorks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DataService.Models.Services
{
    public interface IUserService
    {
        LoginServiceModel CheckLogin(LoginRequestModel model);
        UserServiceModel GetInfoUserById(int id);
    }
    public class UserService : BaseUnitOfWork<UnitOfWork>, IUserService
    {
        private readonly AppSettings _appSettings;
        public UserService(UnitOfWork uow, IOptions<AppSettings> appSettings) : base(uow)
        {
            _appSettings = appSettings.Value;
        }

        public LoginServiceModel CheckLogin(LoginRequestModel model)
        {
            // end code MD5 to check login
            var passwordMD5 = EncryptorService.MD5Hash(model.Password);
            var user = _uow.User.CheckLogin(model.Username, passwordMD5);
            if (user == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.RoleId.ToString())
                    }),
                   // Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                // create secret key to authorize
                var secretKeyString = user.Username + user.Password + "HashMD5ToAuthorize";
                var secretKey = EncryptorService.MD5Hash(secretKeyString);
                var result = new LoginServiceModel
                {
                    Id = user.Id,
                    Token = tokenHandler.WriteToken(token),
                    Username = user.Username,
                    SecretKey = secretKey
                };
                // cap nhat token truoc khi vao app
                return result;
            }
        }

        public UserServiceModel GetInfoUserById(int id)
        {
            var user = _uow.User.GetUserById(id);
            if (user == null)
            {
                return null;
            }
            else
            {
                var houseInfo = _uow.House.GetHouseById(user.HouseId);
                var block = _uow.Block.GetBlockById(houseInfo.BlockId);
                var result = new UserServiceModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Fullname = user.Fullname,
                    DateOfBirth = user.DateOfBirth,
                    Idnumber = user.Idnumber,
                    IdcreatedDate = user.IdcreatedDate,
                    HouseName = houseInfo.HouseName,
                    Floor = houseInfo.Floor,
                    BlockName = block.BlockName,
                    Gender = user.Gender,
                    ProfileImage = user.ProfileImage,
                    SendPasswordTo = user.SendPasswordTo
                };
                return result;
            }
        }


    }
}
