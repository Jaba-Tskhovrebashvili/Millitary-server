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
                throw new BadRequestException("მეილი არავალიდურია");

            if (string.IsNullOrWhiteSpace(admin.Name) || admin.Name.Trim().Length < 3)
                throw new BadRequestException("გთხოვთ შეავსოთ სახელის ველი");

            if (string.IsNullOrWhiteSpace(admin.Surname) || admin.Surname.Trim().Length < 3)
                throw new BadRequestException("გთხოვთ შეავსოთ გვარის ველი");

            var exists = await _unitOfWork.AdminRepository.ExistsByEmailAsync(admin.Email);

            if (exists)
                throw new ConflictException("მსგავსი მეილით ექაუნთი უკვე არსებობს");

            var token = await _authHelper.GenerateTokenRegister(admin);

            await _emailService.SendEmailOtp(admin.Email, token, admin.Name);

            return true;
        }

        public bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email)
                && System.Net.Mail.MailAddress.TryCreate(email, out var addr)
                && addr.Address == email.Trim();
        }

       public async Task<bool> AdminRegister(PasswordDto passwordDto, string token)
        {

                if (passwordDto.Password != passwordDto.ConfirmPassword)
                {
                    throw new BadRequestException("გაიმეორეთ პაროლი სწორად!");
                }
                var regexPattern = @"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*(),.?""':;{}|<>]).{8,16}$";

                if (!Regex.IsMatch(passwordDto.Password, regexPattern))
                {
                    throw new BadRequestException("პაროლი არავალიდურია");
                }

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(passwordDto.Password);
                var verifyToken = await this._authHelper.VerifyJWTToken(token);


            var exists = await _unitOfWork.AdminRepository.ExistsByEmailAsync(verifyToken.Email);
            if (exists)
                throw new ConflictException("მსგავსი მეილით ექაუნთი უკვე არსებობს");

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

        public async Task<Admin> GetProfile(int id)
        {

                var findAdmin = await this._unitOfWork.AdminRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("ადმინი ვერ მოიძებნა"); ;
                var admin = new Admin
                {
                    Id = findAdmin.Id,
                    Name = findAdmin.Name,
                    Surname = findAdmin.Surname,
                    Email = findAdmin.Email,
                };
                return admin;
        }

        public async Task<AdminSignInResponseDto> AdminSignIn(AdminSignInDto adminSignin)
        {

                var findAdmin = await this._unitOfWork.AdminRepository.GetByEmailAsync(adminSignin.Email);
             

                if (findAdmin == null)
                {
                    throw new BadRequestException("მოცემული მეილი რეგისტრირებული არ არის");
                }

                var verified = BCrypt.Net.BCrypt.Verify(adminSignin.Password, findAdmin.Password);
                if (!verified)
                {
                    throw new BadRequestException("პაროლი არასწორია");
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
    }
}
