using System;
using System.Collections.Generic;

//properties represented as columns in the database
namespace CourseworkCauses.Models
{
    public class CauseIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CauseContent { get; set; }
        //relates to user
        public string AuthorId { get; set; }
        public string AuthorEmail { get; set; }
        public DateTime TimeCreated { get; set; }
        //relates to signatures
        public IEnumerable<SignatureModel> Signatures { get; set; }
    }
}
