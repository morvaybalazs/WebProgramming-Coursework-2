//properties represented as columns in the database
//pre populated by asp.net
namespace CourseworkCauses.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}