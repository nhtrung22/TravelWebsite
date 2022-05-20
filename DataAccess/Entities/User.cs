using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; } // PK

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public int UserType { get; set; }

        public int Status { get; set; }

    }
}
