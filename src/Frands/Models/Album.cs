﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frands.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
       public string  AlbumName {get;set;}
        public string Artist { get; set; }
        public string YearReleased { get; set; }

        public string AlbumsHref { get; set; }
    }
}
