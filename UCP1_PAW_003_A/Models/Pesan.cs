using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_003_A.Models
{
    public partial class Pesan
    {
        public int IdJadwal { get; set; }
        public int? JumlahPesan { get; set; }
        public DateTime? TanggalPesan { get; set; }
        public string Status { get; set; }
    }
}
