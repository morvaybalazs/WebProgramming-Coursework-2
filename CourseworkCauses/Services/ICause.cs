using CourseworkCauses.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// defines behaviours/tasks of the services
namespace CourseworkCauses.Services
{
    public interface ICause
    {
        //returns cause by id
        Cause GetById(int id);
        //returns causes by causetype id that it belongs to
        IEnumerable<Cause> GetCausesByCauseType(int id);
        //add new cause
        Task Add(Cause cause);
        //not used yet
        Task EditCauseContent(int id, string newContent);
        //not used yet
        Task Delete(int id);
        //add signatures
        Task AddSignature(Signature signature);
    }
}
