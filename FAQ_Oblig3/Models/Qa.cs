using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAQ_Oblig3.Models
{

    public class Qa
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ. \\-]{2,30}$")]
        public string Type { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ. \\-]{2,30}$")]
        public string Question { get; set; }
        
        public string Answer { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }

}
