using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juventus_házidolgozat
{
    struct Jatekos
    {
        public int Mez;
        public string Nev;
        public string Nemzet;
        public string Poszt;
        public int Ev;
    }
    class Program
    {
        static List<Jatekos> juventus;
        static void Main(string[] args)
        {
            Beolvas();
            F01();
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            F08();
            F09();
            Console.ReadKey();
        }

        private static void F09()
        {
            Console.Write("Bekérendő mez szám: ");
            int m = int.Parse(Console.ReadLine());

            int i = 0;

            while (i < juventus.Count && juventus[i].Mez != m)
            {
                i++;
            }

            if (i < juventus.Count)
            {
                Console.WriteLine("A "+m+"-es mezt "+juventus[i].Nev+" használja.");
            }
            else Console.WriteLine("Ilyen mezszámú játékos nem szerepel az adatbázissban.");
        }

        private static void F08()
        {
            var haromjat = new Dictionary<int, int>();

            foreach (var vizsgalt in juventus)
            {
                if (!haromjat.ContainsKey(vizsgalt.Ev))
                    haromjat.Add(vizsgalt.Ev, 1);
                else haromjat[vizsgalt.Ev]++;
            }

            Console.Write("Ebben az évben 3 játékos is született: ");
            foreach (var vizsgalt in haromjat)
            {
                if (vizsgalt.Value == 3) Console.Write(vizsgalt.Key + ", ");
            }
            Console.WriteLine(" ");
        }

        private static void F07()
        {
            var idos = new Jatekos() { Ev = DateTime.Now.Year };
            foreach (var vizsgalt in juventus)
            {
                if (vizsgalt.Poszt == "csatár" && vizsgalt.Ev < idos.Ev) idos = vizsgalt;
            }
            Console.WriteLine("A legidősebb csatár: "+idos.Nev);
        }

        private static void F06()
        {
            var posztok = new Dictionary<string, int>();
            foreach (var vizsgalt in juventus)
            {
                if (!posztok.ContainsKey(vizsgalt.Poszt))
                    posztok.Add(vizsgalt.Poszt, 1);
                else posztok[vizsgalt.Poszt]++;
            }

            foreach (var vizsgalt in posztok)
            {
                Console.WriteLine("{0, -12} {1}", vizsgalt.Key, vizsgalt.Value);
            }
        }

        private static void F05()
        {
            int osszev = 0;
            foreach (var vizsgalt in juventus)
            {
                osszev += (DateTime.Now.Year - vizsgalt.Ev);
            }
            Console.WriteLine("átlagéletkor: "+( osszev / (float)juventus.Count));
        }

        private static void F04()
        {
            int fiat = 0;
            for (int i = 1; i < juventus.Count; i++)
            {
                if (juventus[i].Ev > juventus[fiat].Ev) fiat = i;
            }
            Console.WriteLine($"a legfiatalabb játékos: "+juventus[fiat].Nev);
        }

        private static void F03()
        {
            int olasz = 0;
            foreach (var vizsgalt in juventus)
            {
                if (vizsgalt.Nemzet == "olasz") olasz++;
            }
            Console.WriteLine(olasz+" olasz játékos van az adatbázisban.");
        }

        private static void F02()
        {
            int i = 0;
            while (i < juventus.Count && juventus[i].Nemzet != "magyar")
            {
                i++;
            }
            if (i < juventus.Count) Console.WriteLine("Van magyar játékos az adatbázisban.");
            else Console.WriteLine("Nincs magyar játékos az adatbázisban.");
        }

        private static void F01()
        {
            Console.WriteLine("Igazolt játékosok: "+juventus.Count);
        }

        private static void Beolvas()
        {
            juventus = new List<Jatekos>();
            var sr = new StreamReader(@"juve.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');

                    juventus.Add(
                    new Jatekos()
                    {
                        Mez = int.Parse(adatok[0]),
                        Nev = adatok[1],
                        Nemzet = adatok[2],
                        Poszt = adatok[3],
                        Ev = int.Parse(adatok[4]),
                    });
            }
            sr.Close();
        }
    }
}
