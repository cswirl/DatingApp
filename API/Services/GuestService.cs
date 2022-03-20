using API.Data;
using API.DTOs;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class GuestService : IGuestService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GuestService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Deprecated or Stand By
        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
        {

            return null;
        }
    }
}
