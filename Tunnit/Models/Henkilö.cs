using System;
using System.Collections.Generic;

namespace Tunnit.Models
{
    public partial class Henkilö
    {
        public Henkilö()
        {
            Tunnit = new HashSet<TunnitCS>();
        }

        public int Id { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Osasto { get; set; }
        public string Tehtävänimike { get; set; }

        public virtual ICollection<TunnitCS> Tunnit { get; set; }
    }
}
