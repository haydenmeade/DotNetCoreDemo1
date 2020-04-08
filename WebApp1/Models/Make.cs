using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vroom.Models
{
    public class Make
    {
        public int Id { get; set; }
        [StringLength(255), Required()]
        public string Name { get; set; }
    }
}
