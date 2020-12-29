using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CritProject.Models
{
    public class CriticModels
    {
        [Required] public int ID { set; get; }

        public string Name { set; get; }

        public string SecondName { set; get; }

        public string Alias { set; get; }

        public string Picture { set; get; }

        public string Descritpion { set; get; }

        public virtual ICollection<ReviewModels> Reviews { get; set; }

        public virtual ICollection<CommentModels> Comments { get; set; }
    }
}