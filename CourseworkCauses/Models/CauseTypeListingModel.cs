namespace CourseworkCauses.Models
//properties represented as columns in the database

{
    public class CauseTypeListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //relates to user
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }
        public int CauseTypeId { get; set; }
        public string CauseTypeName { get; set; }
        public CauseTypeListingModel CauseType { get; set; }
        //relates to signatures
        public int SignatureCount { get; set; }
    }
}
