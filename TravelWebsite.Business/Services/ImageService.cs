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


        public ImageService(TravelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        public Image UploadImage()
        {
            string[] filePaths = Directory.GetFiles(@"C:\Users\nhtru\Source\Repos\nhtrung22\TravelWebsite\DataAccess\Image");
            foreach (var file in string)
            {
                Image img = new Image();
                img.Title = "anh1";

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.Data = ms.ToArray();

                ms.Close();
                ms.Dispose();

                _context.Images.Add(img);
                _context.SaveChanges();
            }
            return Image;
        }
    }
}
