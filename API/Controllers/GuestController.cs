using API.DTOs;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class GuestController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGuestService _guestService;

        public GuestController(IUnitOfWork unitOfWork, IGuestService guestService)
        {
            _unitOfWork = unitOfWork;
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery] UserParams userParams)
        {
            var users = await _unitOfWork.UserRepository.GetMembersAsync(userParams);

            // Response object is inherited from the ControllerBase class
            // AddPaginationHeader() is our custom extension class
            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }
    }
}
