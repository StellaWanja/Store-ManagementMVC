using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //use [Required]
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Models
{
    public class Store
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public string StoreName {get; set; }
        [Required]
        public string StoreNumber { get; set; }
        [Required]
        public string StoreType {get; set; }
        [Required]
        public int StoreProducts {get; set; }
        [Required]
        public string ImageUrl {get; set; }

        //Navigational Properties
        public AppUser User { get; set; }
    }
}
