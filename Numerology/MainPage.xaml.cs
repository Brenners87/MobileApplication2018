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

        //validate Day Entry
        private void DayValid( object sender,EventArgs text)
        { 
            //eliminates backspace crash on computer operation
            if (!string.IsNullOrWhiteSpace(entryDay.Text))
            {
                int day = 0;
                day = Convert.ToInt16(entryDay.Text);
                if (day < 01 || day > 31)
                {
                    DisplayAlert("Day", "Invalid Entry\n  Enter between 1 - 31", "Retry");
                }//innerIf
            }//if
        }

        //validate Month Entry
        private void MonthValid(object sender, TextChangedEventArgs text)
        {
            int dayCheck = 0;
           
            if (!string.IsNullOrWhiteSpace(entryMonth.Text))
            {
                int month = 0;
                month = Convert.ToInt16(entryMonth.Text);

                if (month < 01 || month > 12)
                {
                    DisplayAlert("Month", "Invalid Entry\n Enter between 1 - 12", "Retry");
                }//innerIf

                //further validation of Day/Month compatible
                dayCheck = Convert.ToInt16(entryDay.Text);
                switch (month)
                {
                    case 2:
                        if (dayCheck > 29)//for leap year if necessary
                        {
                            DisplayAlert("Incorrect", "Please enter correct date with month\n" +
                                "  " + dayCheck + " of February\n does not exist", "Retry");
                            InitializeComponent();
                        }
                        break;
                    case 4:
                        if (dayCheck > 30)
                        {
                            DisplayAlert("Incorrect", "Please enter correct date with month\n" +
                                "  " + dayCheck + "st of April\n does not exist", "Retry");
                            InitializeComponent();
                        }//if
                        break;
                    case 6:
                        if (dayCheck > 30)
                        {
                            DisplayAlert("Incorrect", "Please enter correct date with month\n" +
                                "  " + dayCheck + "st of June\n does not exist", "Retry");
                            InitializeComponent();
                        }//if
                        break;
                    case 9:
                        if (dayCheck > 30)
                        {
                            DisplayAlert("Incorrect", "Please enter correct date with month\n" +
                                "  " + dayCheck + "st of September\n does not exist", "Retry");
                            InitializeComponent();
                        }//if
                        break;
                    case 11:
                        if (dayCheck > 30)
                        {
                            DisplayAlert("Incorrect", "Please enter correct date with month\n" +
                                "  " + dayCheck + "st of Novemebr\n does not exist", "Retry");
                            InitializeComponent();
                        }//if
                        break;
                }//switch
            }//largeIf
        }

        //validate  Year Entry
        private void YearValid()
        {
            if (!string.IsNullOrWhiteSpace(entryYear.Text))
            { 
                int year = 0;
                year = Convert.ToInt16(entryYear.Text);
                if (year < 0|| year > 2020)
                {
                    DisplayAlert("Year", "Invalid Entry\n  Enter between 1 - 2020", "Retry");
                }//innerIf
            }//if
        }

        //Main Calculation
        private void Date_Of_Birth(object sender, EventArgs args)
        {
            // declaration of variables
            int day = 0, day2 = 0, month = 0, month2 = 0;
            int centuryYear = 0, centuryYear2 = 0, decadeYear = 0, decadeYear2 = 0;
            int numerology = 0, breakdown=0, breakdown2=0;

            if (string.IsNullOrWhiteSpace(entryDay.Text) || string.IsNullOrWhiteSpace(entryMonth.Text) || string.IsNullOrWhiteSpace(entryYear.Text))
            {
                DisplayAlert("No Entry", "Please enter all values", "Retry");
                InitializeComponent();
            }
            else
            {
                //conversion of String to interger
                day = Convert.ToInt16(entryDay.Text);

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

                centuryYear = Convert.ToInt16(entryYear.Text);
                //breaking down to individual digits
                centuryYear -= decadeYear = centuryYear % 100;
                centuryYear2 = ((centuryYear / 100) % 10);
                centuryYear /= 1000;
                decadeYear2 = decadeYear % 10;
                decadeYear = (decadeYear - decadeYear2) / 10;

                numerology += centuryYear + centuryYear2 + decadeYear + decadeYear2;

                if (numerology > 9 && !(numerology == 11) && !(numerology == 22) && !(numerology == 33))
                {
                    breakdown2 = numerology % 10;
                    breakdown = numerology / 10;
                    numerology = breakdown + breakdown2;
                    if (numerology == 10)
                    {
                        numerology = 1;
                    }//innerIf
                    if (numerology >= 12)
                    {
                        breakdown2 = numerology % 10;
                        breakdown = numerology / 10;
                        numerology = breakdown + breakdown2;
                    }//innerIf
                }//if

                //return String format
                numerologyCalc.Text = " " + numerology;

                //return previous date
                prevDate.Text = " \nLast Entered\n   " + day + " : " + month + " : " + entryYear.Text;

                //call answerPage
                AnswerPage();
            }//Large If/Else
        }

    }
}
