using System;
using System.Collections.Generic;
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

namespace calculator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastnumber , result;
        myenum myenum;
        public MainWindow()
        {
            InitializeComponent();
            percentegebutton.Click += Percentegebutton_Click;
        }

        private void Percentegebutton_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            if (double.TryParse(lapel1.Content.ToString(), out temp)) ;
            temp = (temp / 100);
            if (temp != 0)
                temp *= lastnumber;
            lapel1.Content = temp ;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lapel1.Content = "0";
            lastnumber= 0;
            result = 0;
        }

        private void negativebutton_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(lapel1.Content.ToString(), out lastnumber);
            lastnumber = lastnumber * -1;
            lapel1.Content = lastnumber;
        }

            private void numberoperation_Click(object sender, RoutedEventArgs e)
        {
            int Sum = int.Parse((sender as Button).Content.ToString()) ;
            if (lapel1.Content.ToString() == "0")
            {
                lapel1.Content = Sum.ToString();
            }
            else { lapel1.Content = $"{lapel1.Content}{Sum}"; }
        }

        private void pointbutton_Click(object sender, RoutedEventArgs e)
        {
            if (lapel1.Content.ToString().Contains(",")){}
            else {lapel1.Content = $"{lapel1.Content},"; }
        }

        private void equalbutton_Click(object sender, RoutedEventArgs e)
        {
            double newnumber;
            if (double.TryParse(lapel1.Content.ToString()  , out newnumber)) ;
            {
                switch (myenum)
                {
                    case myenum.addition:
                        result = math.add(lastnumber, newnumber);
                        break;
                    case myenum.multiplication:
                        result = math.multy(lastnumber, newnumber);
                        break;
                    case myenum.sustraction:
                        result = math.sub(lastnumber, newnumber);
                        break;
                    case myenum.division:
                        result = math.divition(lastnumber, newnumber);
                        break;
                }
                lapel1.Content = result; 
            }
        }

        private void poissance_Click(object sender, RoutedEventArgs e)
        {
            double poissance1;
            if (double.TryParse(lapel1.Content.ToString(), out poissance1)) ;
            result = poissance1 * poissance1;
            lapel1.Content = result;
        }

        private void operaton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lapel1.Content.ToString(), out lastnumber))
                lapel1.Content = "0" ;

            if (sender == addbutton)
                myenum = myenum.addition;
            if (sender == multiplybutton)
                myenum = myenum.multiplication;
            if (sender == subbutton)
                myenum = myenum.sustraction;
            if (sender == divitionbutton)
                myenum = myenum.division;

        }
    }
     public enum myenum
    {
       addition,
       sustraction,
       multiplication,
       division
    }
    public class math
    {
        public static double add(double n1,double n2)
        {
            return n1 + n2;
        }
        public static double multy(double n1 , double n2)
        {
            return n1 * n2;
        }
        public static double sub(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double divition(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("You cannot divide by 0", "wrong operation", MessageBoxButton.OK ,MessageBoxImage.Error);
            }
            return n1 / n2;
        }
    }
      
    
}
