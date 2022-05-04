using CourseworkCauses.Data;
using CourseworkCauses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// takes data from models (database) and serves it to the project and its controllers
// services are to be injected into the controllers to handle interactions with the data
namespace CourseworkCauses.Services
{
    public class CauseTypeService : ICauseType
    {
        //interacts with database
        private readonly ApplicationDbContext _context;

        public CauseTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        // creates new causetype(only for admin)
        public async Task Create(CauseType causetype)
        {
            _context.Add(causetype);
            await _context.SaveChangesAsync();

        }
        // deletes caustype not implemented yet
        public async Task Delete(int causetypeId)
        {
            var causetype = GetByID(causetypeId);
            _context.Remove(causetype);
            await _context.SaveChangesAsync();
        }
        // returns all causetypes
        public IEnumerable<CauseType> GetAll()
        {
            return _context.CauseTypes
                .Include(causetype => causetype.Causes);
        }


        //returns first(single) causetype that corresponds to the id that gets passed trough the getby id method
        public CauseType GetByID(int id)
        {
            var causetype = _context.CauseTypes.Where(c => c.Id == id)
                .Include(c => c.Causes).ThenInclude(ca => ca.User)
                .Include(c => c.Causes).ThenInclude(ca => ca.Signatures).ThenInclude(s => s.User).FirstOrDefault();

            return causetype;
        }
        //not used maybe future project
        public Task UpdateCauseTypeDescription(int causetypeId, string newDescription)
        {
            throw new NotImplementedException();
        }
        //not used maybe future project
        public Task UpdateCauseTypeTitle(int causetypeId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
