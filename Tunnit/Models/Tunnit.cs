using System;
using System.Collections.Generic;

namespace Tunnit.Models
{
    public partial class TunnitCS
    {
        public int Id { get; set; }
        public int? TunnitId { get; set; }
        public DateTime Päivämäärä { get; set; }
        public decimal Tunnit1 { get; set; }
        public string Tehtäväkuvaus { get; set; }
        public bool Laskutettava { get; set; }

        public virtual Henkilö TunnitNavigation { get; set; }
    }
}
