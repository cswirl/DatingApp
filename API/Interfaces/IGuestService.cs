using API.DTOs;
using API.Entities;
using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IGuestService
    {
        Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
    }
}
