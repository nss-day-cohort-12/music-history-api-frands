using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frands.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Title { get; set; }
        public int AlbumId { get; set; }
        public string Artist { get; set; }
        public string TracksHref { get; set; }
        public int ListenerId { get; set; }


    }
}
