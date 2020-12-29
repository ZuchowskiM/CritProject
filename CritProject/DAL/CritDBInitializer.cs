using CritProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CritProject.DAL
{
    public class CritDBInitializer<T>: CreateDatabaseIfNotExists<CritContext>
    {
        protected override void Seed(CritContext context)
        {
            GameModels game = new GameModels()
            {
                Title = "League of Legends",
                ProducerID = 1,
                RealeaseDate = new DateTime(2009, 10, 10),
                Type = "MOBA",
                Platforms = "PC",
                Description = "nice game",
                //Reviews = new List<ReviewModels> { new Models.ReviewModels() {ID = 1 } },
                Producer = new ProducerModels() { ID = 1, CompanyName = "Riot Games", HQPlace="USA"}
                
            };

            context.Games.Add(game);
            context.SaveChanges();
        }
    }
}