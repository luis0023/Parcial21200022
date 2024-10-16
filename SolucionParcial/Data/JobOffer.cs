﻿using System;
using System.Collections.Generic;

namespace SolucionParcial.Data;

public partial class JobOffer
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public decimal? Salary { get; set; }

    public string? Location { get; set; }
}
