using Microsoft.Extensions.Configuration.UserSecrets;
using MillitaryService.DTOs;
using MillitaryService.Helpers.Interfaces;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;
using MillitaryService.Services.Interfaces;

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
    }
}
