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
            string person = " ", work = " ", challenge = " ";

            numerologyNum = Convert.ToInt16(number);
            switch (numerologyNum)
            { 
                case 1:
                    person = "Independent\nCreative ";
                    work = "Natural Leader\nAmbitious";
                    challenge = "Self doubt\nRisk taker ";
                   break;
                case 2:
                    person = "Mediator\nDiplomatic";
                    work = "Team player\nVisionary";
                    challenge = "Oversensitive\nIndecisiveness ";
                    break;
                case 3:
                    person = "Innovative\nCommunicative";
                    work = "Educator\nEntertainer";
                    challenge = "Frustration\nEscapist ";
                    break;
                case 4:
                    person = "Dedicated\nTrustworthy";
                    work = "Managerial\nEntrepeneur";
                    challenge = "Stubborn\nObsessive ";
                    break;
                case 5:
                    person = "Progressive\nAdventerous";
                    work = "Humanitarian\nCommunicator";
                    challenge = "Inflexible\nDistractible ";
                    break;
                case 6:
                    person = "Nurturer\nRighteousness ";
                    work = "Councillor\nAuthority ";
                    challenge = "Overwhelmed\nSelf-righteousness ";
                    break;
                case 7:
                    person = "Analytical\nObserver ";
                    work = "Scientic\nStudious";
                    challenge = "Pessimistic\nSecretive ";
                    break;
                case 8:
                    person = "Organizational\nGovern  ";
                    work = "Executive\nGovernment";
                    challenge = "Work-a-olic\nMaterialist ";
                    break;
                case 9:
                    person = "compassionate\nGenerous";
                    work = "Artistic\nPhilosophical ";
                    challenge = "selflessness\nOver-burdened ";
                    break;
                case 11:
                    person = "Enlighteners \n";
                    work = "Spiritual Balance ";
                    challenge = "overambitious\nVanity ";
                    break;
                case 22:
                    person = "Creators \n ";
                    work = "Grandiose thinker ";
                    challenge = "Underachievement\nSelf-imposed pressure ";
                    break;
                case 33:
                    person = "Master teachers\n ";
                    work = "Mover & shaker";
                    challenge = "Impulsive\nIdealist ";
                    break;
                default:
                    person = "Please Return \n& Enter \nBirthdate";
                    work = "\n\n";
                    challenge = "\n\n";
                    break;
            }
            personality.Text = person;
            work_career.Text = work;
            challenges.Text = challenge;
        }
       
	}
}