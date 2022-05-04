using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseworkCauses.Models;
using CourseworkCauses.Data;
using Microsoft.EntityFrameworkCore;

// takes data from models (database) and serves it to the project and its controllers
// services are to be injected into the controllers to handle interactions with the data

namespace CourseworkCauses.Services
{
    public class CauseService : ICause
    {
        //interacts with database
        private readonly ApplicationDbContext _context;

        public CauseService(ApplicationDbContext context)
        {
            _context = context;
        }
        //creates new cause
        public async Task Add(Cause cause)
        {
            _context.Add(cause);
            await _context.SaveChangesAsync();
        }
        //adds signature
        public async Task AddSignature(Signature signature)
        {
            _context.Signatures.Add(signature);
            await _context.SaveChangesAsync();
        }
        //deletes cause not implemented yet
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        //edits cause not implemented yet
        public Task EditCauseContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        //returns first cause that corresponds to the id that gets passed trough the getby id method
        public Cause GetById(int id)
        {
            return _context.Causes.Where(cause => cause.Id == id)
                .Include(cause => cause.User)
                .Include(cause => cause.Signatures).ThenInclude(signature => signature.User)
                .Include(cause => cause.CauseType)
                .First();
        }

        // returns causes by type to categorically display
        public IEnumerable<Cause> GetCausesByCauseType(int id)
        {
            return _context.CauseTypes.Where(causetype => causetype.Id == id).First().Causes;
        }
    }
}
