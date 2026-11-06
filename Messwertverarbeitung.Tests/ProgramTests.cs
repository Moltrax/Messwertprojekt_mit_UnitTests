using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messwertverarbeitung;

namespace Messwertverarbeitung.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Durchschnitt_Werte1Bis5_Ergibt3()
        {
            // Arrange: Erwarteten Durchschnitt festlegen.
            double erwartet = 3.0;

            // Act: Durchschnitt berechnen.
            double ergebnis = (double)MesswertBerechnung.Average(1, 2, 3, 4, 5);

            // Assert: Ergebnis mit dem erwarteten Wert vergleichen.
            Assert.AreEqual(erwartet, ergebnis, 1e-10);
        }

        [TestMethod]
        public void SumAll_WerteHebenSichAuf_Ergibt0()
        {
            // Arrange: Gültige Messwerte, deren Summe null ist.
            double m1 = -5, m2 = 5, m3 = 0, m4 = 0, m5 = 0;
            double? erwartet = 0.0;

            // Act: Summe berechnen.
            double? ergebnis = MesswertBerechnung.SumAll(m1, m2, m3, m4, m5);

            // Assert: Bewusst rot, weil HatMesswerte die Messwerte fälschlich als fehlend erkennt.
            Assert.AreEqual(erwartet, ergebnis);
        }
    }
}

