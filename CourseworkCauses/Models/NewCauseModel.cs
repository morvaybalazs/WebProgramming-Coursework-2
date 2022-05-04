//properties represented as columns in the database

namespace CourseworkCauses.Models
{
    public class NewCauseModel
    {
        //relates to causetype
        public string CauseTypeName { get; set; }
        public int CauseTypeId { get; set; }
        //relates to user
        public string AuthorEmail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
