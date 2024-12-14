using System;
using System.Collections.Generic;

namespace CreditCard.Models;

public partial class CreditCard
{
    public Guid Id { get; set; }

    public string CardNumber { get; set; } = null!;

    public string ExpiryDate { get; set; } = null!;

    public string CardholderName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int Cvv { get; set; }
}
