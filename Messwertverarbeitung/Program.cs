using System;

namespace Messwertverarbeitung
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            double[] werte = new double[5];
            bool beendet = false;
            while (!beendet)
            {
                Console.WriteLine("\n[1] Messwerte eingeben  [2] Messwerte anzeigen  [3] Summe  [4] Durchschnitt  [5] Beenden");
                Console.Write("Auswahl: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        for (int i = 0; i < werte.Length; i++)
                        {
                            Console.Write($"Messwert {i + 1}: ");
                            while (!double.TryParse(Console.ReadLine(), out werte[i]))
                                Console.Write("Ungültige Eingabe. Bitte erneut eingeben: ");
                        }
                        break;
                    case "2":
                        if (!MesswertBerechnung.HatMesswerte(werte[0], werte[1], werte[2], werte[3], werte[4]))
                            Console.WriteLine("Du musst zuerst Messwerte eingeben!");
                        else
                            for (int i = 0; i < werte.Length; i++)
                                Console.WriteLine($"Messwert {i + 1}: {werte[i]}");
                        break;
                    case "3":
                        double? summe = MesswertBerechnung.SumAll(werte[0], werte[1], werte[2], werte[3], werte[4]);
                        Console.WriteLine(summe.HasValue ? $"Summe der Messwerte: {summe.Value}" : "Du musst zuerst Messwerte eingeben!");
                        break;
                    case "4":
                        double? durchschnitt = MesswertBerechnung.Average(werte[0], werte[1], werte[2], werte[3], werte[4]);
                        Console.WriteLine(durchschnitt.HasValue ? $"Durchschnitt der Messwerte: {durchschnitt.Value}" : "Du musst zuerst Messwerte eingeben!");
                        break;
                    case "5": beendet = true; break;
                    default: Console.WriteLine("Ungültige Auswahl."); break;
                }
            }
        }
    }

    public static class MesswertBerechnung
    {
        // Absichtlich fehlerhaft: Gültige Werte können sich zu null summieren.
        public static bool HatMesswerte(double m1, double m2, double m3, double m4, double m5)
        {
            return Summe(m1, m2, m3, m4, m5) != 0;
        }

        private static double Summe(double m1, double m2, double m3, double m4, double m5)
        {
            return m1 + m2 + m3 + m4 + m5;
        }

        private static double Durchschnitt(double m1, double m2, double m3, double m4, double m5)
        {
            return Summe(m1, m2, m3, m4, m5) / 5.0;
        }

        // null bedeutet: HatMesswerte meldet, dass keine Werte vorliegen.
        public static double? SumAll(double m1, double m2, double m3, double m4, double m5)
        {
            return HatMesswerte(m1, m2, m3, m4, m5) ? Summe(m1, m2, m3, m4, m5) : (double?)null;
        }

        public static double? Average(double m1, double m2, double m3, double m4, double m5)
        {
            return HatMesswerte(m1, m2, m3, m4, m5) ? Durchschnitt(m1, m2, m3, m4, m5) : (double?)null;
        }
    }
}
