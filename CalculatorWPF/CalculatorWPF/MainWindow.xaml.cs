using CalculatorWPF.Code;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Label? LastResultShow;
        public static Label? ResultShow;
        public MainWindow()
        {
            InitializeComponent();
            ResultShow = Lb_Result;
            LastResultShow = Lb_LastResult;
        }

        private void Bt_Zero_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += "0";
        }

        private void Bt_One_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += "1";
        }

        private void Bt_Two_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += "2";
        }

        private void Bt_Three_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += "3";
        }

        private void Bt_Four_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += "4";
        }

        private void Bt_Five_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += "5";
        }

        private void Bt_Six_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += "6";
        }

        private void Bt_Seven_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += "7";
        }

        private void Bt_Eight_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += "8";
        }

        private void Bt_Nine_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += "9";
        }

        private void Bt_Backspace_Click(object sender, RoutedEventArgs e)
        {
            Calculation.RemoveLastNumber();
        }

        private void Bt_C_Click(object sender, RoutedEventArgs e)
        {
            Calculation.SoftReset();
        }
        private void Bt_CE_Click(object sender, RoutedEventArgs e)
        {
            Calculation.HardReset();
        }

        private void Bt_Comma_Click(object sender, RoutedEventArgs e)
        {
            Calculation.OutputText += ",";
        }

        private void Bt_Power_Click(object sender, RoutedEventArgs e)
        {
            Calculation.MathPowerUp(2);
            Lb_LastResult.Content += "²";
        }

        

        private void Bt_Square_Click(object sender, RoutedEventArgs e)
        {
            Calculation.Square();
            Lb_LastResult.Content = "√" + Lb_LastResult.Content;
        }

        private void Bt_Plus_Click(object sender, RoutedEventArgs e)
        {
            Calculation.Operuj(MatWays.Plus);
        }

        private void Bt_Minus_Click(object sender, RoutedEventArgs e)
        {
            Calculation.Operuj(MatWays.Minus);
        }

        private void Bt_Multi_Click(object sender, RoutedEventArgs e)
        {
            Calculation.Operuj(MatWays.Multiply);
        }

        private void Bt_Devide_Click(object sender, RoutedEventArgs e)
        {
            Calculation.Operuj(MatWays.Devide);
        }

        private void Bt_GetResult_Click(object sender, RoutedEventArgs e)
        {
            Calculation.Calculate();
        }

        private void Bt_OneDevidedX_Click(object sender, RoutedEventArgs e)
        {
            Calculation.DevideByX();
        }

        private void Bt_Precentage_Click(object sender, RoutedEventArgs e)
        {
            Calculation.Procetage();
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MinimazedButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.WindowState == WindowState.Maximized)
        //    {
        //        WindowState = WindowState.Normal;
        //    }
        //    else
        //    {
        //        this.WindowState = WindowState.Maximized;
        //    }
            
        //}

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                    Calculation.OutputText += "0";
                    break;
                case Key.NumPad1:
                    Calculation.OutputText += "1";
                    break;
                case Key.NumPad2:
                    Calculation.OutputText += "2";
                    break;
                case Key.NumPad3:
                    Calculation.OutputText += "3";
                    break;
                case Key.NumPad4:
                    Calculation.OutputText += "4";
                    break;
                case Key.NumPad5:
                    Calculation.OutputText += "5";
                    break;
                case Key.NumPad6:
                    Calculation.OutputText += "6";
                    break;
                case Key.NumPad7:
                    Calculation.OutputText += "7";
                    break;
                case Key.NumPad8:
                    Calculation.OutputText += "8";
                    break;
                case Key.NumPad9:
                    Calculation.OutputText += "9";
                    break;
                case Key.Multiply:
                    Calculation.Operuj(MatWays.Multiply);
                    break;
                case Key.Subtract:
                    Calculation.Operuj(MatWays.Minus);
                    break;
                case Key.Add:
                    Calculation.Operuj(MatWays.Plus);
                    break;
                case Key.Divide:
                    Calculation.Operuj(MatWays.Devide);
                    break;
                case Key.Decimal:
                    Calculation.OutputText += ",";
                    break;
                case Key.Enter:
                    Calculation.Calculate();
                    break;
                case Key.Escape:
                    Calculation.SoftReset();
                    break;
                case Key.Back:
                    Calculation.RemoveLastNumber();
                    break;
            }
        }
    }
}
