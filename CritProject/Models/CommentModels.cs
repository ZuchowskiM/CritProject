using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CritProject.Models
{
    public class CommentModels
    {
        [Required] public int ID { set; get; }

        public int ReviewID { set; get; }

        public string Text { set; get; }

        public string OwnerName { set; get; }

        public DateTime CommentDate { set; get; }

        public virtual CriticModels Critic { set; get; }

        public virtual ReviewModels Review { set; get; }
    }
}