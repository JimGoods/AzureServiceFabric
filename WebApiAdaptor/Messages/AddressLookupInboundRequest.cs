using System.ComponentModel.DataAnnotations;

namespace WebApiService.Messages
{
    public class AddressLookupInboundRequest
    {
        [Required]
        [RegularExpression(@"^(GIR 0AA)|[a-z-[qvx]](?:\d|\d{2}|[a-z-[qvx]]\d|[a-z-[qvx]]\d[a-z-[qvx]]|[a-z-[qvx]]\d{2})(?:\s?\d[a-z-[qvx]]{2})?$", ErrorMessage = "Invalid Postcode")]
        public string PostCode
        {
            get;
            set;
        }

        [Required]
        public string BuildingNameOrNumber
        {
            get;
            set;
        }
    }
}