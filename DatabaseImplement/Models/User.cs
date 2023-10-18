using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Models
{
    [Index(nameof(Login),IsUnique = true)]
    public class User
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
