using MillitaryService.DTOs;
using MillitaryService.Helpers.Interfaces;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;
using MillitaryService.Services.Interfaces;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace MillitaryService.Services.Implementations
{
    public class PersonnelService: IPersonnelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonnelHelper _personnelHelper;
        
        public PersonnelService(IUnitOfWork unitOfWork, IPersonnelHelper personnelHelper)
        {
            this._unitOfWork = unitOfWork;
            this._personnelHelper = personnelHelper;
        }

        public async Task<Personnel> PersonnelProfile(int PersonnelId)
        {
            try
            {
             return await this._unitOfWork.PersonnelRepository.GetByIdAsync(PersonnelId);
             
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }


        }


        public async Task<bool> PersonnelRegister(PersonnelDto personnelDto)
        {
            try
            {
                var personelHelper = await this._personnelHelper.PersonnelValidate(personnelDto);

                var findPersonByEmail= await this._unitOfWork.PersonnelRepository.ExistsByEmailAsync(personelHelper.Email);
                if (findPersonByEmail)
                {
                    throw new Exception("მსგავსი მეილით ექაუნთი უკვე არსებობს");
                }

                var findPersonByPersonNumber = await this._unitOfWork.PersonnelRepository.ExistsByPersNumberAsync(personelHelper.PersonalNumber);

                if (findPersonByPersonNumber)
                {
                    throw new Exception("მსგავსი პირადი ნომრით ექაუნთი უკვე არსებობს");
                }

                var personnel = new Personnel {
                Name= personelHelper.Name,
                Surname=personelHelper.Surname,
                Email=personelHelper.Email,
                PersonalNumber= personelHelper.PersonalNumber,
                DateOfBirth= personelHelper.DateOfBirth,
                RankId= personelHelper.RankId,
                PhoneNumber= personelHelper.PhoneNumber,
                EnlistmentDate= personelHelper.EnlistmentDate,
                IsActive =true
                };

                await this._unitOfWork.PersonnelRepository.AddAsync(personnel);
                await this._unitOfWork.SaveChangesAsync();
                return true;

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> PersonnelUpdate(PersonnelDto personnelDto, int personnelId)
        {
            try {
                var personelHelper = await this._personnelHelper.PersonnelValidate(personnelDto);
                var findPersonById = await this._unitOfWork.PersonnelRepository.GetByIdAsync(personnelId);
                if (findPersonById==null)
                {
                    throw new Exception("დაფიქსირდა შეცდომა");
                }

                var personnel = new Personnel
                {
                    Id=personnelId,
                    Name = personelHelper.Name,
                    Surname = personelHelper.Surname,
                    Email = personelHelper.Email,
                    PersonalNumber = personelHelper.PersonalNumber,
                    DateOfBirth = personelHelper.DateOfBirth,
                    RankId = personelHelper.RankId,
                    PhoneNumber = personelHelper.PhoneNumber,
                    EnlistmentDate = personelHelper.EnlistmentDate,
                    IsActive = true
                };

                this._unitOfWork.PersonnelRepository.UpdateAsync(personnel);
                await this._unitOfWork.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> PersonnelRemove(int personnelId)
        {
            try
            {
                var findPersonById = await this._unitOfWork.PersonnelRepository.GetByIdAsync(personnelId);
                if (findPersonById == null)
                {
                    throw new Exception("დაფიქსირდა შეცდომა");
                }

                await this._unitOfWork.PersonnelRepository.DeleteAsync(personnelId);
                await this._unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
