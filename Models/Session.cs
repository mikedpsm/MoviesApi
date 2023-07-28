﻿using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Session 
{
    public int? MovieId { get; set; }
    public virtual Movie Movie { get; set; }
    public int? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
}
