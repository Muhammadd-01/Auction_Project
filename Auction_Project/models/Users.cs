﻿using System.ComponentModel.DataAnnotations;
namespace Auction_Project.models
{
    public class Users
    {
        [Key]
        public int id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}
