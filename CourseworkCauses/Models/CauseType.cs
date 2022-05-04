using System;
using System.Collections.Generic;
//properties represented as columns in the database

namespace CourseworkCauses.Models
{
    public class CauseType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreated { get; set; }
        //relates to causes
        public virtual IEnumerable<Cause> Causes { get; set; }
    }
}
