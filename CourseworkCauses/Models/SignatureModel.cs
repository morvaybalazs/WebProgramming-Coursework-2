using System;
//properties represented as columns in the database

namespace CourseworkCauses.Models
{
    public class SignatureModel
    {
        public int Id { get; set; }
        //relates to user
        public string AuthorId { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string SignatureContent { get; set; }
        //relates to cause
        public int CauseId { get; set; }
        public string CauseTitle { get; set; }
        public string CauseContent { get; set; }
        //relates to causetype
        public string CauseTypeName { get; set; }
        public int CauseTypeId { get; set; }

    }
}
