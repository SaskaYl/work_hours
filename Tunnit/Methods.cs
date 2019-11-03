using System;
using System.Collections.Generic;
using System.Text;
using Tunnit.Models;
using System.Linq;

namespace Tunnit
{
    public class Methods
    {
        public string LuoHenkilö()
        {
            tuntikrjausContext db = new tuntikrjausContext();


            Console.WriteLine("syötä etunimi");
            string etunimi = Console.ReadLine();
            Console.WriteLine("syötä sukunimi");
            string sukunimi = Console.ReadLine();

            Console.WriteLine("syötä osastosi");
            string osasto = Console.ReadLine();

            Console.WriteLine("syötä tehtävänimike");
            string tehtävänimike = Console.ReadLine();

            Henkilö h = new Henkilö();
            //h.Id = id;
            h.Etunimi = etunimi;
            h.Sukunimi = sukunimi;
            h.Osasto = osasto;
            h.Tehtävänimike = tehtävänimike;

            db.Henkilö.Add(h);
            db.SaveChanges();
            return etunimi;
        }

        public void KirjaaTunnit(int id)
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Kirjaa työtuntisi.");
            tuntikrjausContext db = new tuntikrjausContext();

            Console.WriteLine("syötä pvm");
            DateTime pvm = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("syötä tunnit");
            decimal tunnit = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("syötä tehtäväkuvaus.");
            string tk = Console.ReadLine();
            Console.WriteLine("onko tämä laskutettava tunti? syötä 'kyllä' tai 'ei'.");
            string lask = Console.ReadLine();

            bool laskutettava = false ;
            if(lask == "kyllä")
            {
                laskutettava = true;
            }



            TunnitCS t = new TunnitCS();

            t.Päivämäärä = pvm;
            t.Tunnit1 = tunnit;
            t.TunnitId = id;
            t.Tehtäväkuvaus = tk;
            t.Laskutettava = laskutettava;

            db.Tunnit.Add(t);
            db.SaveChanges();

        }

        public int HaeUudenID(string etunimi)
        {
            tuntikrjausContext db = new tuntikrjausContext();
            var uudenId = from i in db.Henkilö
                          where i.Etunimi == etunimi
                          select i;

            return uudenId.First().Id;

        }

        public void RaportointiKaikki(DateTime alku, DateTime loppu)
        {
            Console.WriteLine();
            tuntikrjausContext db = new tuntikrjausContext();
            var kaikkitunnit = from k in db.Tunnit
                               select k;
            decimal tunnit = 0;
            foreach (var item in kaikkitunnit)
            {
                if (item.Päivämäärä<=loppu&& item.Päivämäärä >= alku)
                {
                tunnit += item.Tunnit1;
                    Console.WriteLine($"ID: {item.TunnitId} tehtäväkuvaus: {item.Tehtäväkuvaus}");

                }
            }
                Console.WriteLine("työtunnit yhteensä: " + tunnit);

        }
    }
}
