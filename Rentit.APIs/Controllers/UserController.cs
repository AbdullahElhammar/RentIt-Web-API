using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rentit.BL;
using Rentit.BL.Dtos;
using Rentit.DAL;
using System.IO;
using System.Security.Claims;

namespace Rentit.APIs.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IClientManager UserManager;
        private readonly IRequestHostManger requestHostManager;
        private readonly IPropertyManager PropertyManager;
        private readonly IRequestRentManager requestRentManager;
        private readonly IClientRepo ClientRepo;

        public UserController(IClientManager _userManager, IRequestHostManger _RequestHostManager
            , IPropertyManager _PropertyManager, IRequestRentManager _requestRentManager, IClientRepo _ClientRepo)
        {
            this.UserManager = _userManager;
            this.requestHostManager = _RequestHostManager;
            this.PropertyManager = _PropertyManager;
            this.requestRentManager = _requestRentManager;
            this.ClientRepo = _ClientRepo;
        }

        [HttpGet]
        [Authorize(Policy = "UserRole")]
        [Route("UserInfo")]
        public ActionResult<UserDto> GetUserDetails()
        {
            int userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            UserDto? user = UserManager.GetUserDetails(userid);
            if (user == null) { return NotFound(); }
            return user;
        }

        [HttpPut]
        [Route("UpdateUser/{id}")]
        public ActionResult UpdateUser(UserUpdateDto UserDto)
        {
            var IsFound = UserManager.UpdateUser(UserDto);
            if (!IsFound) { return NotFound(); }
            return Ok("User Updated Successfully");
        }

        [HttpPost]
        // [Authorize(Policy = "UserRole")]
        [Route("RequestHost/{Id}")]
        public async Task<ActionResult> AddRequestHost([FromForm] UploadRequestHostDto requestHost,[FromRoute]int Id)
        {

            //PropertyAddDto? PropToAdd = JsonConvert.DeserializeObject<PropertyAddDto>(requestHost.propertyAdd);
            PropertyAddDto? PropToAdd = new PropertyAddDto()
            {
                Property_Name = requestHost.Property_Name,
                Nighly_Price=requestHost.Nighly_Price,
                Description=requestHost.Description,    
                Nums_Guests=requestHost.Nums_Guests,    
                Nums_Beds=requestHost.Nums_Beds,    
                Nums_Bathrooms = requestHost.Nums_Bathrooms,
                Nums_Bedrooms = requestHost.Nums_Bedrooms,
                Street = requestHost.Street,
                City = requestHost.City,
                Building_no = requestHost.Building_no,
                Building_name = requestHost.Building_name,
                District_name = requestHost.District_name,
                Location_url = requestHost.Location_url,
                GovernateId = requestHost.GovernateId,
                PlaceType_ID = requestHost.PlaceType_ID,
                PropetyTypeId = requestHost.PropetyTypeId,
                attrubutesToAddDto = requestHost.attrubutesToAddDto
            };
            var AllowedExtensions = new string[] { ".png", ".jpg", ".svg" };
            var MaxFileSize = 4_000_000; // 4 MB

            List<string> uploadedFiles = new List<string>();

            for (int i = 0; i < requestHost.imgs.Count; i++)
            {
                // Check extension
                var extension = Path.GetExtension(requestHost.imgs[i].FileName);
                if (!AllowedExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase))
                {
                    return BadRequest("Extension is not valid");
                }

                // Check file size
                if (requestHost.imgs[i].Length > MaxFileSize)
                {
                    return BadRequest("File size exceeds the maximum allowed size of 4 MB");
                }

                // Generate unique file name
                var newFileName = $"{PropToAdd?.Property_Name}{PropToAdd?.City}{PropToAdd?.Street}{i + 1}{extension}";

                // Save the file
                using (var stream = new FileStream($"Assets/PropertiesImages/{PropToAdd?.Property_Name}{PropToAdd?.City}{PropToAdd?.Street}{i + 1}{extension}", FileMode.Create))
                {
                    await requestHost.imgs[i].CopyToAsync(stream);
                }

                ImageToAddRequestHostDto img = new ImageToAddRequestHostDto
                {
                    Img_URL = newFileName,
                    Img_order = (i + 1),
                };
                PropToAdd?.imageToAddRequestHostDtos.Add(img);
            }
         //   int userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            requestHostManager.AddRequestHost(PropToAdd, Id);
            return Ok();
        }
        [HttpPut]
        [Authorize(Policy = "UserRole")]
        [Route("Userimg")]
        public async Task<ActionResult<UserImgDto>> UploadFileDTO([FromForm] IFormFile Clientimg)
        {
            int userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            Client? client = ClientRepo.GetUserDetails(userid);
            var imgURL = "";
            if (Clientimg != null)
            {
                string fileext = Clientimg.FileName.Split('.').Last();
                using (var fs = new FileStream($"Assets/UserImages/{client.FName}{client.LName}{client.Id}.{fileext}", FileMode.Create))
                {
                    await Clientimg.CopyToAsync(fs);
                    imgURL = client.Img_URL = $"{client.FName}{client.LName}{client.Id}.{fileext}";
                }
                UserManager.EditCLientImg(imgURL, client);
                return Ok(new UserImgDto(true, "Sucess", imgURL));
            }
            else { return BadRequest(new UserImgDto(false, "Failed", " ")); }
        }

        [HttpPost]
        [Authorize(Policy = "AdminRole")]
        [Route("Add/{id}")]
        public ActionResult AcceptRequestHost(int id) 
        {
            var IsFound = requestHostManager.AcceptHostRequestByAdmin(id);
            if(!IsFound) { return NotFound("Cant find the request please add your request for hosting"); } 
            PropertyManager.Add(id);
            return Created();
        }

        [HttpPut]
        [Authorize(Policy = "AdminRole")]
        [Route("Cancel/{id}")]
        public ActionResult CancelRequestHost(int id)
        {
            var IsFound = requestHostManager.CancelHostRequestByAdmin(id);
            if (!IsFound) { return NotFound("Cant find the request please add your request for hosting"); }
        
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "UserRole")]
        [Route("AcceptRentHost/{id}")]
        public ActionResult AcceptRentRequestbyHost(int id) 
        {
            var IsFound =  requestRentManager.AcceptByHost(id);
            if (!IsFound) { return NotFound("Cant find the property"); }
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "UserRole")]
        [Route("CancelRentHost/{id}")]
        public ActionResult CancelRentRequestbyHost(int id)
        {
            var IsFound = requestRentManager.CancelByHost(id);
            if (!IsFound) { return NotFound("Cant find the property"); }
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "AdminRole")]
        [Route("AcceptRentAdmin/{id}")]
        public ActionResult AcceptRentRequestByAdmin(int id)
        {
          var IsFound =   requestRentManager.AcceptByAdmin(id);
            if (!IsFound) { return BadRequest("Cant find the request or the host acceptence still pending"); }
            return Created();
        }

        [HttpPut]
        [Authorize(Policy = "AdminRole")]
        [Route("CancelRentAdmin/{id}")]
        public ActionResult CancelRentRequestByAdmin(int id)
        {
            var IsFound = requestRentManager.CancelByAdmin(id);
            if (!IsFound) { return BadRequest("Cant find the request"); }
            return Ok();
        }

        [HttpGet]
        [Authorize(Policy = "AdminRole")]
        [Route("Rent")]
        public ActionResult<List<RequestRentReadDto>> GetAllRentRequests()
        {
            return requestRentManager.GetAllForAdmin().ToList();
        }

        [HttpGet]
        [Authorize(Policy = "AdminRole")]
        [Route("Host")]
        public ActionResult<List<RequestHostReadDto>> GetAllHostRequest()
        {
            return requestHostManager.GetAll().ToList();    
        }
    }
}
