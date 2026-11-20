using MillitaryService.DTOs;
using MillitaryService.Models;
using MillitaryService.Repositories.Interfaces;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Services.Implementations
{
    public class PersonnelAssignmentsService: IPersonnelAssignmentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonnelAssignmentsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddAssignmentAsync(PersonnelAssignmentsDto newAssignment)
        {
                var currentAssignment =
           await _unitOfWork.personnelAssignmentsRepository.GetCurrentAssignmentAsync(newAssignment.PersonnelId);

                if (currentAssignment != null)
                {
                    currentAssignment.IsCurrent = false;
                    currentAssignment.EndDate = newAssignment.StartDate;

                    this._unitOfWork.personnelAssignmentsRepository.Update(currentAssignment);
                }


                var newPersonnelAssaign = new PersonnelAssignments
                {
                 PersonnelId = newAssignment.PersonnelId,
                 MilitaryUnitId=newAssignment.MilitaryUnitId,
                 PositionId=newAssignment.PositionId,
                 StartDate = newAssignment.StartDate,
                 EndDate = null,
                 IsCurrent=true
                };

                await _unitOfWork.personnelAssignmentsRepository.AddAsync(newPersonnelAssaign);

                await _unitOfWork.SaveChangesAsync();

        }

        public async Task<List<PersonnelAssignments>> GetPersonnelAssignments(int personnelId)
        {
            return await this._unitOfWork.personnelAssignmentsRepository.GetPersonnelAssignments(personnelId);
        }

        public async Task UpdatePersonnelAssignments(PersonnelAssignmentsDto personnelAssaign,int personnelAssaignId)
        {
            var personelAssaign = new PersonnelAssignments {
             Id= personnelAssaignId,
             PersonnelId= personnelAssaign.PersonnelId,
             MilitaryUnitId=personnelAssaign.MilitaryUnitId,
             PositionId = personnelAssaign.PositionId,
             StartDate = personnelAssaign.StartDate,
             EndDate = personnelAssaign.EndDate,
             IsCurrent = personnelAssaign.IsCurrent
            };
            this._unitOfWork.personnelAssignmentsRepository.Update(personelAssaign);
            await this._unitOfWork.SaveChangesAsync();
        }


    }
}
