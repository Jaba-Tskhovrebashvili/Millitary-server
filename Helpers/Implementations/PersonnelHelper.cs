using Microsoft.CodeAnalysis.FlowAnalysis;
using MillitaryService.DTOs;
using MillitaryService.Helpers.Interfaces;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MillitaryService.Helpers.Implementations
{
    public class PersonnelHelper: IPersonnelHelper
    {
        public PersonnelHelper() { }

        private static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public async Task<PersonnelDto> PersonnelValidate(PersonnelDto personnel)
        {
            DateTime today = DateTime.Today;


                if (!IsValidEmail(personnel.Email)) 
                {
                    throw new BadRequestException("მეილი არავალიდურია");
                }

                if (!string.IsNullOrWhiteSpace(personnel.Name) && (personnel.Name.Length < 2 || personnel.Name.Length > 50))
                {
                    throw new BadRequestException("სახელი უნდა შეიცავდეს 2-დან 50 სიმბოლომდე");
                }

                if (!string.IsNullOrWhiteSpace(personnel.Surname) && (personnel.Surname.Length < 2 || personnel.Surname.Length > 50))
                {
                    throw new BadRequestException("გვარი უნდა შეიცავდეს 2-დან 50 სიმბოლომდე");
                }

                if (personnel.PersonalNumber.Length != 11)
                {
                    throw new BadRequestException("პირადი ნომერი უნდა შეადგენდეს 11 სიმბოლოს!");
                }

                if (personnel.DateOfBirth == default)
                {
                    throw new BadRequestException("დაბადების თარიღი აუცილებელია!");
                }

                int age = today.Year - personnel.DateOfBirth.Year;
                if (personnel.DateOfBirth.Month > today.Month || (personnel.DateOfBirth.Month == today.Month && personnel.DateOfBirth.Day > today.Day))
                {
                    age--;
                }

                if (age < 18)
                {
                    throw new BadRequestException("პერსონალი უნდა იყოს სრულწლოვანი");
                }

                if (personnel.RankId <= 0)
                {
                    throw new BadRequestException("რანგის არჩევა აუცილებელია!");
                }
                if (!string.IsNullOrWhiteSpace(personnel.PhoneNumber) &&
                    (personnel.PhoneNumber.Length < 4 || personnel.PhoneNumber.Length > 50))
                {
                    throw new BadRequestException("ტელეფონის ნომერი უნდა შეიცავდეს 4-დან 50 სიმბოლომდე!");
                }
                if (personnel.EnlistmentDate == default)
                {
                    throw new BadRequestException("გაწვევის თარიღი აუცილებელია!");
                }

                return personnel;

        }
    }
}
