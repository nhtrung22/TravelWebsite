using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.DataAccess.EF;
using TravelWebsite.DataAccess.Entities;
using System.IO;

namespace TravelWebsite.Business.Services
{
    public class ImageService
    {
        private TravelDbContext _context;
        private readonly IMapper _mapper;

        public ImageService(TravelDbContext context)
        {
            _context = context;
        }


    }
}
