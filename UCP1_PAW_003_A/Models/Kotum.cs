using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_003_A.Models
{
    public partial class Kotum
    {
        public int IdKotaAsal { get; set; }
        public int? IdKotaTujuan { get; set; }
        public string Kota { get; set; }
    }
}
