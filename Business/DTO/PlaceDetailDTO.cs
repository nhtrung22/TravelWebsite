using TW.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.DataAccess.DTO
{
    public class PlaceDeatailDTO
    {

        public bool Wifi { get; set; }

        public bool TV { get; set; }

        public bool AC { get; set; }

        public bool CarParking { get; set; }

        public int Size { get; set; }

        public int Square { get; set; }


        //public int PlaceID { get; set; }
        //public virtual Place Place { get; set; }

        // Place - Place Detail
        public int PlaceID { get; set; }
        public Place Place { get; set; }

    }
}
