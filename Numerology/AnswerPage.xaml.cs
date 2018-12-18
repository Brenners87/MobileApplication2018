using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Numerology
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnswerPage : ContentPage
	{
		public AnswerPage (string number)
		{
			InitializeComponent ();
            calcNumber.Text = number;
            Explanation(calcNumber.Text);
        }
        private void Explanation(string number)
        {
            int numerologyNum = 0;
            numerologyNum = Convert.ToInt16(number);
            personality.Text = "Please return \n & enter \n Date of Birth\n";
            work_career.Text = "€€€\n";
            challenges.Text = "|_=_=_|\n";
        }
	}
}