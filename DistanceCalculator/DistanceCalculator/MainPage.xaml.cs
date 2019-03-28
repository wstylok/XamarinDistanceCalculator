using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DistanceCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateBtn_Clicked(object sender, EventArgs e)
        {            
            if(SelectFromUnit.SelectedIndex == -1)
            {
                Result.Text = "Select 'From' unit!";
            }
            else
            {
                if(calcFrom.Text == null)
                {
                    Result.Text = "Type a distance!";
                }
                else
                {
                    try
                    {
                        if (double.TryParse(calcFrom.Text, out double cFrom))
                        {
                            double val = cFrom;
                            if (SelectToUnit.SelectedIndex == -1)
                            {
                                Result.Text = "Select 'To' unit!";
                            }
                            else
                            {
                                Calculate(val);
                            }
                        }
                        else
                        {
                            Result.Text = "Type a numeric distance!";
                        }
                    }
                    catch { }

                    
                }
            }
        }

        public void Calculate(double value)
        {
            int sf = SelectFromUnit.SelectedIndex;
            int st = SelectToUnit.SelectedIndex;
            double converter = 0;

            if (sf == st)
            {
                Result.Text = "You selected the same From/To units!";
            }
            else
            {
                if (sf == 0 && st == 1)
                    converter = 0.621371192;
                if (sf == 1 && st == 0)
                    converter = 1.609344;

                Result.Text = $"{calcFrom.Text} {SelectFromUnit.Items[SelectFromUnit.SelectedIndex]} is {value * converter} {SelectToUnit.Items[SelectToUnit.SelectedIndex]}";
            }
        }
    }
}
