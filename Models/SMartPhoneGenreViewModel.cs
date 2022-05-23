using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPhone.Models
{
    public class SMartPhoneGenreViewModel
    {
        public List<SMartPhone>? SMartPhones { get; set; }
        public SelectList? Genres { get; set; }
        public string? SMartPhoneGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
