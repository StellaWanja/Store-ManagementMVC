using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Models.ViewModels.VM
{
    public class StoresUsersVM
    {
        public string Id { get; set; } 
        public string UserId { get; set; }
        public string StoreName { get; set; }
        public string StoreNumber { get; set; }
        public string StoreType { get; set; }
        public int StoreProducts { get; set; }
        public string ImageUrl { get; set; }

    }
}