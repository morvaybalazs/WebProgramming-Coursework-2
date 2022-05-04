namespace CourseworkCauses.Models
//properties represented as columns in the database

{
    public class CauseListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //relates to user
        public string AuthorEmail { get; set; }
        public string AuthorId { get; set; }
        public string TimeCreated { get; set; }
        //relates to causetype
        public int CauseTypeId { get; set; }
        public string CauseTypeName { get; set; }
        public CauseTypeListingModel CauseTypeListingModel { get; set; }
        //relates to signatures
        public int SignaturesCount { get; set; }
    }
}
