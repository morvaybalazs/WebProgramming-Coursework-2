using CourseworkCauses.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// defines behaviours/tasks of the services
namespace CourseworkCauses.Services
{
    public interface ICauseType
    {
        //returns causetype by id
        CauseType GetByID(int id);
        IEnumerable<CauseType> GetAll();
        //create new causetype
        Task Create(CauseType causetype);
        //not used yet
        Task UpdateCauseTypeTitle(int causetypeId, string newTitle);
        //not used yet
        Task UpdateCauseTypeDescription(int causetypeId, string newDescription);
        //not used yet
        Task Delete(int causetypeId);
    }
}
