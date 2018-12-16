using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Numerology
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AnswerPage));
        }

        private void Date_Of_Birth(object sender, EventArgs e)
        {
            // declaration of variables
            int day = 0, day2 = 0, month = 0, month2 = 0;
            int centuryYear = 0, centuryYear2 = 0, decadeYear = 0, decadeYear2 = 0;
            int numerology = 0;

            //conversion of String to interger
            day = Convert.ToInt16(entryDay.Text);
            //test for correct entry

            day2 = day % 10;
            day = (day - day2) / 10;
            day += day2;
            switch (day)
            {
                case 10:
                    day = 1;
                    break;
                case 11:
                    day = 2;
                    break;
            }
            //assign to numerology
            numerology += day;

            //calculate month
            month = Convert.ToInt16(entryMonth.Text);
            //test for correct entry

            month2 = month % 10;
            month -= month2;

            //assign to numerology
            numerology += month;
            if (numerology == 10)
            {
                numerology = 1;
            }
            numerology += month2;

            //calculate year
            centuryYear = Convert.ToInt16(entryYear.Text);
            //test for correct entry

            //breaking down to individual digits
            centuryYear -= decadeYear = centuryYear % 100;
            centuryYear /= 1000;
            centuryYear2 = ((centuryYear / 100) % 10);
            decadeYear2 = decadeYear % 10;
            decadeYear = (decadeYear - decadeYear2) / 10;

            numerology += centuryYear;
            if (numerology > 9)
            {
                centuryYear = numerology % 10;
                numerology = (numerology / 10) + centuryYear;
            }//create function LLL above9Test(numerology,value)

            numerology += centuryYear2;
            if (numerology > 9)
            {
                centuryYear2 = numerology % 10;
                numerology = (numerology / 10) + centuryYear2;
            }

            numerology += decadeYear;
            if (numerology > 9)
            {
                decadeYear = numerology % 10;
                numerology = (numerology / 10) + decadeYear;
            }

            numerology += decadeYear2;
            if (numerology > 9)
            {
                decadeYear2 = numerology % 10;
                numerology = (numerology / 10) + decadeYear2;
            }
            switch (numerology)
            {
                case 10:
                    numerology = 1;
                    break;
                case 11:
                    numerology = 11;
                    break;
                case 22:
                    numerology = 22;
                    break;
                case 33:
                    numerology = 33;
                    break;
            }//switch
             //return String format
             numerologyCalc.Text = " Your Numerology is \n" + "  \t\t" + numerology;
            
        }

    }
}
