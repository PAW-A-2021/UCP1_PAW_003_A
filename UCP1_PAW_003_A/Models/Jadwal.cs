using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_003_A.Models
{
    public partial class Jadwal
    {
        public int IdKotaAsal { get; set; }
        public int? IdKotaTujuan { get; set; }
        public int? Biaya { get; set; }
        public DateTime? JamBerangkat { get; set; }
    }
}
