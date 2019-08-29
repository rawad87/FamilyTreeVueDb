﻿using System;

namespace FamilyTreeVeuDb.Model

{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string LifeStatus { get; set; }
        public int FatherId { get; set; }
        public int MotherId { get; set; }
    }
}