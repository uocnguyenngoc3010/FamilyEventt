﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FamilyEventt.Models
{
    public partial class Family
    {
        public int Id { get; set; }
        public string EventBookerId { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberPhone { get; set; }
        public bool Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Description { get; set; }
        public string Relation { get; set; }
        public bool Status { get; set; }

        public virtual EventBooker EventBooker { get; set; }
    }
}