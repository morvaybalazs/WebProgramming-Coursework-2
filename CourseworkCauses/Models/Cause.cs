using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//properties represented as columns in the database
namespace CourseworkCauses.Models
{
    public class Cause
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime TimeCreated { get; set; }
        //relates to user and causetype
        public virtual ApplicationUser User { get; set; }
        public virtual CauseType CauseType { get; set; }
        //relates to signatures
        public virtual IEnumerable<Signature> Signatures { get; set; }
    }
}
