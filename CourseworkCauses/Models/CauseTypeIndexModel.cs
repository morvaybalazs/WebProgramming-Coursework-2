using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//properties represented as columns in the database

namespace CourseworkCauses.Models
{
    public class CauseTypeIndexModel
    {
        public IEnumerable<CauseTypeListingModel> CauseTypeList { get; set; }
    }
}
