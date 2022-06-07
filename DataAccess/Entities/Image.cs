using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TravelWebsite.DataAccess.Entities
{

    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        // Place - Image
        public int CurrentPlaceId { get; set; }
        public Place Place { get; set; }
    }
}