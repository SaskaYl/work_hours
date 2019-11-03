using System;
using Tunnit.Models;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Tunnit
{
    class Program
    {

        StreamReader r = new StreamReader("id.txt");


        static List<int> idLista = new List<int>();
        /*static userID = */
        static void Main(string[] args)
        {
            Methods m = new Methods();

            Console.WriteLine("tervetuloa tuntikirjausohjelmaan. Syötä id:si");
            int id = Convert.ToInt32(Console.ReadLine());
            if (idLista.Contains(id))
            {
                m.KirjaaTunnit(id);
            }
            else
            {
                string etunimi = m.LuoHenkilö();
                int uudenID = m.HaeUudenID(etunimi);
                idLista.Add(uudenID);
                m.KirjaaTunnit(uudenID);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Syötä päivämäärät joiden väliltä haluat tulostaa työtunnit");
            Console.WriteLine("syötä alkupvm");
            DateTime alku = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("syötä loppupvm");

            DateTime loppu = Convert.ToDateTime(Console.ReadLine());


            m.RaportointiKaikki(alku, loppu);


            //tuntikrjausContext db = new tuntikrjausContext();

            //var henkilöt = from h in db.Henkilö
            //               select h;

            //foreach (var h in henkilöt)
            //{
            //    Console.WriteLine(h.Etunimi);
            //}
        }

    }
}
