using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CritProject.Models
{
    public class ProducerModels
    {
        [Required] public int ID { set; get; }

        public string CompanyName { set; get; }

        public int Value { set; get; }

        public string HQPlace { set; get; }

        //public virtual ICollection<ReviewModels> Reviews { get; set; }

        //public virtual ICollection<GameModels> Games { get; set; }
    }
}