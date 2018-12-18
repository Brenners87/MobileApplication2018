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

        private async void AnswerPage()
        {
            await Navigation.PushAsync(new AnswerPage(numerologyCalc.Text));
        }

        private void Date_Of_Birth(object sender, EventArgs e)
        {
            // declaration of variables
            int day = 0, day2 = 0, month = 0, month2 = 0;
            int centuryYear = 0, centuryYear2 = 0, decadeYear = 0, decadeYear2 = 0;
            int numerology = 0, breakdown=0, breakdown2=0, test=0;

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
            if (month > 9)
            {
                month = 1;
            }
            else
            {
                month = 0;
            }
            month += month2;

            //assign to numerology
            numerology += month;

            //calculate year
            centuryYear = Convert.ToInt16(entryYear.Text);

            //breaking down to individual digits
            centuryYear -= decadeYear = centuryYear % 100;
            centuryYear2 = ((centuryYear / 100) % 10);
            centuryYear /= 1000;
            decadeYear2 = decadeYear % 10;
            decadeYear = (decadeYear - decadeYear2) / 10;

              test = numerology += centuryYear + centuryYear2 + decadeYear + decadeYear2;
            
            if (numerology > 9 && !(numerology == 11) && !(numerology == 22) && !(numerology == 33)))
            {
                breakdown2 = numerology % 10;
                breakdown = numerology/10;
                numerology = breakdown + breakdown2;
                if (numerology == 10)
                {
                    numerology = 1;
                }//innerIf
            }//if

            //return String format
            numerologyCalc.Text = " "+ numerology ;

            testing.Text = " actual number "+ test +" 1st digit " + breakdown+ " 2nd digit  " + breakdown2 ;  

            //call answerPage
            AnswerPage();
        }

    }
}
