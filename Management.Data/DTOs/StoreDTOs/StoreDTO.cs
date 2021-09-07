using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Management.Models;

namespace Management.Data.DTOs.StoreDTOs
{
    public class StoreDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string StoreName {get; set; }
        public string StoreNumber { get; set; }
        public string StoreType {get; set; }
        public int StoreProducts {get; set; }
    }
}
