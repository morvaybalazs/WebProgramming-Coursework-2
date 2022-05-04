using System.Collections.Generic;
//properties represented as columns in the database

namespace CourseworkCauses.Models
{
    public class CauseTypeTopicModel
    {
        public CauseTypeListingModel CauseType { get; set; }
        //relates to causes
        public IEnumerable<CauseListingModel> Causes { get; set; }
    }
}
