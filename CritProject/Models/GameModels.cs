using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CritProject.Models
{
    public class GameModels
    {


        [Required] public int ID { get; set; }

        public string Title { get; set; }


        public int ProducerID { get; set; }

        [Display(Name = "Realease Date")]
        public DateTime RealeaseDate { get; set; }


        public string Type { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        //public double AvrRating { get; set; }

        public string Platforms { get; set; }

       public virtual ICollection<ReviewModels> Reviews { get; set; }

       public virtual ProducerModels Producer { get; set; }

      

    }
}