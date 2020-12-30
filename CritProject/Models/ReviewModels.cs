using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CritProject.Models
{
    public class ReviewModels
    {
        [Required] public int ID { set; get; }

        public String ReviewTitle { set; get; }

        public DateTime PublishDate { set; get; }

        public String ReviewText { set; get; }

        public int CriticID { set; get; }

        public int GameID { set; get; }

        public double Rating { set; get; }

        public virtual GameModels Game { set; get; }

        public virtual CriticModels Critic { set; get; }

        public virtual ICollection<CommentModels> Comments { get; set; }

    }
}