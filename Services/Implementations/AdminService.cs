using Microsoft.Extensions.Configuration.UserSecrets;
using MillitaryService.DTOs;
using MillitaryService.Helpers.Interfaces;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;
using MillitaryService.Services.Interfaces;
using System.Text.RegularExpressions;

namespace MillitaryService.Services.Implementations
{
    public class AdminService:IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IAuthHelper _authHelper;
        public AdminService(IUnitOfWork unitOfWork,
        IEmailService emailService,
        IAuthHelper authHelper) {
            this._unitOfWork = unitOfWork;
            this._emailService = emailService;
            this._authHelper = authHelper;
        }

        public async Task<bool> VerifyEmailAsync(AdminDto admin)
        {
            if (!IsValidEmail(admin.Email))
                throw new ArgumentException("მეილი არავალიდურია");

            var exists = await _unitOfWork.AdminRepository
                .ExistsByEmailAsync(admin.Email);

            if (exists)
                throw new InvalidOperationException(
                    "მსგავსი მეილით ექაუნთი უკვე არსებობს");

            if (string.IsNullOrWhiteSpace(admin.Name) ||
                admin.Name.Trim().Length < 3)
                throw new ArgumentException(
                    "გთხოვთ შეავსოთ სახელის ველი");

            if (string.IsNullOrWhiteSpace(admin.Surname) ||
                admin.Surname.Trim().Length < 3)
                throw new ArgumentException(
                    "გთხოვთ შეავსოთ გვარის ველი");

            var token = await _authHelper.GenerateTokenRegister(admin);

            await _emailService.SendEmailOtp(
                admin.Email,
                token,
                admin.Name);

            return true;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                return new System.Net.Mail.MailAddress(email).Address == email;
            }
            catch
            {
                return false;
            }
        }

       public async Task<bool> AdminRegister(PasswordDto passwordDto, string token)
        {
            try
            {

                if (passwordDto.Password != passwordDto.ConfirmPassword)
                {
                    throw new ArgumentException("გაიმეორეთ პაროლი სწორად!");
                }
                var regexPattern = @"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*(),.?""':;{}|<>]).{8,16}$";

                if (!Regex.IsMatch(passwordDto.Password, regexPattern))
                {
                    throw new ArgumentException("პაროლი არავალიდურია");
                }

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(passwordDto.Password);
                var verifyToken = await this._authHelper.VerifyJWTToken(token);
                var admin = new Admin
                {
                    Name = verifyToken.Name,
                    Surname = verifyToken.Surname,
                    Email = verifyToken.Email,
                    Password = passwordHash,
                    Created_At = DateTime.Now,
                };

                await this._unitOfWork.AdminRepository.AddAsync(admin);
                await this._unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Admin> GetProfile(int id)
        {
            try
            {
                var findAdmin = await this._unitOfWork.AdminRepository.GetByIdAsync(id);
                var admin = new Admin
                {
                    Id = findAdmin.Id,
                    Name = findAdmin.Name,
                    Surname = findAdmin.Surname,
                    Email = findAdmin.Email,
                };
                return admin;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }   
        
        }

        public async Task<AdminSignInResponseDto> AdminSignIn(AdminSignInDto adminSignin)
        {
            try
            {
                var findAdmin = await this._unitOfWork.AdminRepository.GetByEmailAsync(adminSignin.Email);
             

                if (findAdmin == null)
                {
                    throw new Exception("მოცემული მეილი რეგისტრირებული არ არის");
                }

                var verified = BCrypt.Net.BCrypt.Verify(adminSignin.Password, findAdmin.Password);
                if (!verified)
                {
                    throw new Exception("პაროლი არასწორია");
                }
                var token = await this._authHelper.GenerateAdminToken((int)findAdmin.Id);
                var admin = new Admin
                {
                    Id = findAdmin.Id,
                    Name = findAdmin.Name,
                    Surname = findAdmin.Surname,
                    Email = findAdmin.Email,
                };
                return new AdminSignInResponseDto { Admin=admin,Token=token };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
