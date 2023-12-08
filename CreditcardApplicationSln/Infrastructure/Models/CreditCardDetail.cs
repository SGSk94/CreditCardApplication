using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class CreditCardDetail
{
    public int Id { get; set; }

    public string CardNumber { get; set; } = null!;

    public string CardName { get; set; } = null!;

    public int CardCvv { get; set; }

    public DateTime ValidFromDateMonth { get; set; }

    public DateTime VaildFromDateYear { get; set; }

    public DateTime ValidExpiryDateMonth { get; set; }

    public DateTime ValidExpiryDateYear { get; set; }

    public string CreditBy { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }
}
