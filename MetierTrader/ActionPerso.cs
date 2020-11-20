using System;
using System.Collections.Generic;
using System.Text;

namespace MetierTrader
{
    public class ActionPerso
    {
        private int numTrader;
        private int numActionPerso;
        private string nomActionPerso;
        private double coutTotal;

        public ActionPerso(int unTrader, int unNumPerso, string unNomPerso, double uncoutTotal)
        {
            NumTrader = unTrader;
            NumActionPerso = unNumPerso;
            NomActionPerso = unNomPerso;
            coutTotal = uncoutTotal;
        }

        public int NumTrader { get => numTrader; set => numTrader = value; }
        public int NumActionPerso { get => numActionPerso; set => numActionPerso = value; }
        public string NomActionPerso { get => nomActionPerso; set => nomActionPerso = value; }
    }
}
