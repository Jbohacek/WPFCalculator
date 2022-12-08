using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorWPF.Code
{
    public static class Calculation
    {
        private static Label? Lb_Result = MainWindow.ResultShow;
        private static Label? Lb_LastResult = MainWindow.LastResultShow;

        private static string _OutputText = "0";
        public static double OutputDouble { get { return Convert.ToDouble(_OutputText); } }

        public static string LastOutputText { set { if(Lb_LastResult !=null)Lb_LastResult.Content = value; } }


        public static string OutputText { 
            get 
            {
                return _OutputText;
            }
            set
            {
                //Kontrola, aby nebyla na zacatku 0
                if (_OutputText == "0" && value == "00") return;

                // Aby to Prepsalo nulu a nebo dalo cislo za carku
                if (value != "0") if (_OutputText == "0" && (value != "00" && value != "0," )) if (value.Length > 0) { value = value.Substring(1, 1); }
                // Kontrola aby nebyli 2 carky
                if (value.Length > 0) if (value.Substring(value.Length - 1, 1) == "," && _OutputText.Contains(",")) return;


                //Kontrola Aby se nepsalo za destinou carku nuly zbytecne - nevim zda to implementovat
                //if (value.Substring(value.Length - 1, 1) == "0" && _OutputText.Contains(",")) return;

                //Zmena velikosti
                if (OutputText.Length < 7)
                { if (Lb_Result != null) Lb_Result.FontSize = 75; }
                if (OutputText.Length > 7)
                { if (Lb_Result != null) Lb_Result.FontSize = 50; }
                if (OutputText.Length > 10)
                { if (Lb_Result != null) Lb_Result.FontSize = 25; }
                if (OutputText.Length > 20)
                { if (Lb_Result != null) Lb_Result.FontSize = 10; }
                //Zmena Velikosti

                _OutputText = value;
                if(Lb_Result != null) Lb_Result.Content = _OutputText;
            }
        }

        public static void RemoveLastNumber()
        {
            if (_OutputText.Length > 0)
            {
                OutputText = _OutputText.Substring(0, _OutputText.Length - 1);
                if (_OutputText.Length == 0)
                {
                    OutputText = "0";
                }
            }
        }

        public static void SoftReset()
        {
            OutputText = "0";
        }
        public static void HardReset()
        {
            OutputText = "0";
            LastOutputText = "";
            Operace = MatWays.None;
        }


        public static void MathPowerUp(int PowerCislo)
        {
            LastOutputText = OutputText;
            OutputText = Convert.ToString(Math.Pow(OutputDouble, PowerCislo));
        }

        public static void Square()
        {
            LastOutputText = OutputText;
            OutputText = Convert.ToString(Math.Sqrt(OutputDouble));
        }

        public static void DevideByX()
        {
            LastOutputText = "1 / " + OutputText;
            OutputText = Convert.ToString(1 / OutputDouble); 
        }

        public static void Procetage()
        {
            if (Operace == MatWays.None) return;

            string promena = OutputText;

            if (promena.Contains(","))
            {
                promena = promena.Insert(promena.IndexOf(",") - 2, ",");
                promena = promena.Remove(promena.IndexOf(",", promena.IndexOf(",") + 1), 1);
                if (promena.Length == 5) promena = "0" + promena;
            }
            else
            {
                promena = promena.Insert(promena.Length - 2, ",");
                if (promena.Length == 3) promena = "0" + promena;
            }
            OutputText = promena;
        }




        private static MatWays Operace = MatWays.None;
        private static double PrveCislo = 0;

        public static void Operuj(MatWays OperaceZadana)
        {
            
            PrveCislo = OutputDouble;
            
            char posledniZnamenko = '+';
            switch (OperaceZadana)
            {
                case MatWays.Plus:
                    posledniZnamenko = '+';
                    break;
                case MatWays.Minus:
                    posledniZnamenko = '-';
                    break;
                case MatWays.Devide:
                    posledniZnamenko = '÷';
                    break;
                case MatWays.Multiply:
                    posledniZnamenko = '×';
                    break;
            }
            LastOutputText = PrveCislo.ToString() + " " + posledniZnamenko;
            SoftReset();
            Operace = OperaceZadana;
        }

        public static void Calculate()
        {
            if (Operace == MatWays.None)
            {
                return;
            }
            double vysledek = 0;
            switch (Operace)
            {
                case MatWays.None:
                    break;
                case MatWays.Plus:
                    vysledek = OutputDouble + PrveCislo;
                    break;
                case MatWays.Minus:
                    vysledek = PrveCislo - OutputDouble;
                    break;
                case MatWays.Devide:
                    if (OutputDouble == 0) { MessageBox.Show("Nemůžeš dělit nulou", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);break; }
                    vysledek = PrveCislo / OutputDouble;
                    break;
                case MatWays.Multiply:
                    vysledek = PrveCislo * OutputDouble;
                    break;

            }
            Operace = MatWays.None;
            if (Lb_LastResult != null) LastOutputText = Lb_LastResult.Content + " " + OutputText;

            OutputText = vysledek.ToString();
        }

        
    }
}
