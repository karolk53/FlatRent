﻿namespace FlatRent.Entities;

public class Flat : Property
{
    public int Id { get; set; }
    public Address Address { get; set; }
}