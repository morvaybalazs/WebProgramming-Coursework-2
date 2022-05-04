using System;
//properties represented as columns in the database

namespace CourseworkCauses.Models
{
    public class Signature
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeCreated { get; set; }
        //relates to user
        public virtual ApplicationUser User { get; set; }
        public virtual Signature Signatures { get; set; }
        //realtes to cause
        public virtual Cause Cause { get; set; }
    }
}
