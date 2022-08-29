using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entities
{
    public class ShortLink
    {

        [Key]
        public int Id { get; set; }

        public string Link { get; set; }

        public string ShortenLink { get; set; }


    }
}
