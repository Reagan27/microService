using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MicroServiceAuthentication.Data;
using MicroServiceAuthentication.Models;
using MicroServiceAuthentication.Services.IServices;

namespace MicroServiceAuthentication.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IJWtTokenGenerator _jwtGenerator;
        private readonly AppDbContext _context;
        public UserServices(AppDbContext appDbContext, IMapper mapper, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IJWtTokenGenerator jWtTokenGenerator)
        {
            _context = appDbContext;
            _mapper = mapper;
            _jwtGenerator = jWtTokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AssignUserRole(string email, string Rolename)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                //If User Exists and we can assign a role
                //Now check if the role exists
                if (!_roleManager.RoleExistsAsync(Rolename).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(Rolename));

                }
                await _userManager.AddToRoleAsync(user, Rolename);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
        {
            //Get User by Username
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginRequestDto.Username.ToLower());
            
            //Check if the password is valid

            var isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (!isValid || user == null)
            {

                new LoginResponseDTO();

            }
            //This if username and password are valid
            var roles = await _userManager.GetRolesAsync(user);

            //Create Token

            var token = _jwtGenerator.GenerateToken(user, roles);

            var loggeduser = new LoginResponseDTO()
            {
                User = _mapper.Map<UserDTO>(user),
                Token = token

            };
            return loggeduser;
        }

        public async Task<string> RegisterUser(RegisterRequestDTO registerRequestDto)
        {
            var user = _mapper.Map<IdentityUser>(registerRequestDto);

            try
            {
                var result = await _userManager.CreateAsync(user, registerRequestDto.Password);

                if (result.Succeeded)
                {
                    //if success return Return a string

                    //var get User 
                    return " ";
                }

                else
                {
                    //identity Error if any
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
