using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CritProject.Models
{
    public class TypeModels
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GameModels> Games { get; set; }
    }
}