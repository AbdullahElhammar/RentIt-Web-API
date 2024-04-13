using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rentit.BL;
using Rentit.BL.Dtos;
using Rentit.DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rentit.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<Account> userManager;
        private readonly IClientManager clientManager;

        public AccountController(IConfiguration _configuration, UserManager<Account> _userManager
            ,IClientManager _clientManager)
        {
            configuration = _configuration;
            userManager = _userManager;
            clientManager= _clientManager;  
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto Credentials)
        {
            //hal el user mawgood wla laaa han3ml check 
            //law mawgood arga3 error 
            //law logged ya5od token law laa mash hay5od 
            Account? account = await userManager.FindByNameAsync(Credentials.UserName);
            if (account == null) return BadRequest("User not found");
            //check logged or not 
            if (await userManager.IsLockedOutAsync(account)) return BadRequest("Try again");
            //check 3la passwrod 
            bool IsAuthenticated = await userManager.CheckPasswordAsync(account, Credentials.Password);
            if (!IsAuthenticated)
            {//zwd 3dd marat el faileurs
                await userManager.AccessFailedAsync(account);
                return Unauthorized("Wrong credentials");
            }
            //generate token 
            var userclaims = await userManager.GetClaimsAsync(account);
            // choosing Hashing aloghrithim
            string? secertKey = configuration.GetValue<string>("Secertkey");
            var secertKeyInBytes = Encoding.ASCII.GetBytes(secertKey);
            //instal identity.Tokens laibrary  
            var key = new SymmetricSecurityKey(secertKeyInBytes);
            var MethodUsedInToken = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            //install install-package System.IdentityModel.Tokens.Jwt
            var exp = DateTime.Now.AddMinutes(20);
            var Jwt = new JwtSecurityToken(
                claims: userclaims,
                notBefore: DateTime.Now,
                expires: exp,
                issuer:"Backend app",
                audience:"Rentit",
                signingCredentials:MethodUsedInToken);
            // create token 
            var tokenhandler = new JwtSecurityTokenHandler();
            string TokenString = tokenhandler.WriteToken(Jwt);

            return new TokenDto
            {
                Token = TokenString,
                ExpiryDate = exp
            };
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<string>> Register(RegisterDto registerDTO)
        {
            Client UserToAdd = new Client
            {
                FName = registerDTO.FName,
                LName = registerDTO.LName,  
                Email = registerDTO.Email,  
                Img_URL = "default.jpg",
                JoinedDate = DateTime.Now,  
                RoleId =2 ,
            };
            clientManager.AddUser(UserToAdd);
            Account NewAcc = new Account
            {
                UserName = registerDTO.UserName,    
                Email = registerDTO.Email, 
                ClientiD=UserToAdd.Id
            };
            //msh haynfa3 27ot password 3ashan heya hashed fi el data base 
            //eli hay3ml hash hwa el user manager 
            var Createresult = await userManager.CreateAsync(NewAcc,registerDTO.Password);
            clientManager.SaveChanges();
            if (!Createresult.Succeeded)
                return BadRequest(Createresult.Errors);
            var UserClaims = new List<Claim>
            {
            new Claim (ClaimTypes.NameIdentifier,NewAcc.ClientiD.ToString()),
            new Claim (ClaimTypes.Email,NewAcc.Email),
            new Claim (ClaimTypes.Role,"User"),
            };
            await userManager.AddClaimsAsync(NewAcc, UserClaims);

            return Ok();
        }
    }
}
