using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CC_9_Code_First.Models
{
    public class Movies
    {
        [Key]
        public int Mid { get; set; }
        public string MovieName { get; set; }
        public string DirectorName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfRelease { get; set; }
    }
}