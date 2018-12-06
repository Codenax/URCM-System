﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCR_ManagementSystem.Models.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public long StudentContactNo { get; set; }
        public DateTime RegData { get; set; }
        public string StudentAddress { get; set; }
        public int DepartmentId { get; set; }
        public string RegistrationNumber { get; set; }

    }
}