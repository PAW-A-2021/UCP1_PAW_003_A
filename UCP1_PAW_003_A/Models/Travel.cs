using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_003_A.Models
{
    public partial class Travel
    {
        public int? NoPolisi { get; set; }
        public int? NoKerangka { get; set; }
        public int IdKotaAsal { get; set; }
        public int? IdKotaTujuan { get; set; }
    }
}
