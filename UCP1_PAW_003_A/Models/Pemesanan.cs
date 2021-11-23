using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_003_A.Models
{
    public partial class Pemesanan
    {
        public int IdPesan { get; set; }
        public DateTime? TanggalPesan { get; set; }
        public int? IdJadwal { get; set; }
        public int? JumlahPesan { get; set; }
    }
}
