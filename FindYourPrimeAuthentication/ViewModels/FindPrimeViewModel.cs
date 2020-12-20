using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace FindYourPrimeAuthentication.ViewModels
{
    public class FindPrimeViewModel
    {
        [Required]
        public BigInteger Number { get; set; }
    }
}
