using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class PlaceDetail
    {
        [Key]
        public int DetailID { get; set; }  // PK

        public bool Wifi { get; set; }

        public bool TV { get; set; }

        public bool AC { get; set; }

        public bool CarParking { get; set; }

        public int Size { get; set; }

        public int Square { get; set; }

        public int PlaceID { get; set; }
        public virtual Place Place { get; set; }
    }
}
