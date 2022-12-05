using System;
using System.Collections.Generic;

namespace BooksDB;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public double? Price { get; set; }

    public string? Desc { get; set; }
}
