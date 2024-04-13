using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rentit.BL.Dtos
{
    public class UploadRequestHostDto
    {
        [JsonIgnore]
        public List<IFormFile> imgs { get; set; } = new();
        public string Property_Name { get; set; } = string.Empty;
        public int Nighly_Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Nums_Guests { get; set; }
        public int Nums_Beds { get; set; }
        public int Nums_Bathrooms { get; set; }
        public int Nums_Bedrooms { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Building_no { get; set; }
        public string Building_name { get; set; } = string.Empty;
        public string District_name { get; set; } = string.Empty;
        public string Location_url { get; set; } = string.Empty;
        public int GovernateId { get; set; }
        public int PlaceType_ID { get; set; }
        public int PropetyTypeId { get; set; }
        public List<int> attrubutesToAddDto { get; set; } = new();
    }
}
