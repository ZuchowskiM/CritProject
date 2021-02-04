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

        [Display(Name = "Review Title")]
        public String ReviewTitle { set; get; }

        [Display(Name = "Publish Date")]
        public DateTime PublishDate { set; get; }

        [Display(Name = "Review")]
        public String ReviewText { set; get; }

        [Display(Name = "Critic")]
        public int CriticID { set; get; }

        [Display(Name = "Game")]
        public int GameID { set; get; }

        public double Rating { set; get; }

        public virtual GameModels Game { set; get; }

        public virtual CriticModels Critic { set; get; }

        public virtual ICollection<CommentModels> Comments { get; set; }

    }
}