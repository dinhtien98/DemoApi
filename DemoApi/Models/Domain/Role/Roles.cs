﻿using System.Numerics;

namespace DemoApi.Models.Domain.Role
{
    public class Roles
    {
        public int Id { get; set; } 
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public int DeletedFlag { get; set; } = 0;
        public DateTime? DeletedTime { get; set; }
    }
}
