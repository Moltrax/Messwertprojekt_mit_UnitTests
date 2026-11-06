using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messwertverarbeitung.Tests
{
    internal class Archive
    {
        //[DataTestMethod]
        //[DataRow(1.0, 2.0, 3.0, 4.0, 5.0, 3.0)]
        //[DataRow(-5.0, -3.0, -4.0, 0.0, 0.0, -2.4)]
        //[DataRow(0.5, 0.5, 0.0, 0.0, 0.0, 0.2)]
        public void Durchschnitt_VerschiedeneWerte_ErgibtErwartetenWert(
            double m1, double m2, double m3, double m4, double m5, double erwartet)
        {
            // Arrange: Jede DataRow liefert fünf Messwerte und den erwarteten Durchschnitt.

            // Act: Durchschnitt für die jeweilige Datenzeile berechnen.
            double ergebnis = (double)MesswertBerechnung.Average(m1, m2, m3, m4, m5);

            // Assert: Das Ergebnis dieser Datenzeile überprüfen.
            Assert.AreEqual(erwartet, ergebnis, 1e-10);
        }
    }
}
