using RondApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RondApp.Views
{
    public partial class AssistancePage : ContentPage
    {
        public AssistancePage()
        {
            InitializeComponent();

            foreach(string val in HelpValues.Origin.All())
            {
                OriginPicker.Items.Add(val);
            }
            foreach (string val in HelpValues.Gender.All())
            {
                GenderPicker.Items.Add(val);
            }
            foreach (string val in HelpValues.Hygiene.All())
            {
                HygienePicker.Items.Add(val);
            }
            foreach (string val in HelpValues.Health.All())
            {
                HealthPicker.Items.Add(val);
            }
            AgeRangeEntry.TextChanged += AgeRangeEntry_TextChanged;
            SearchBtn.Clicked += SearchBtn_Clicked;
        }

        private void SearchBtn_Clicked(object sender, EventArgs e)
        {
           
        }
        
        private void AgeRangeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 3)
                AgeRangeEntry.Text = e.NewTextValue.Substring(0, e.NewTextValue.Length - 2);

            if (int.Parse(e.NewTextValue) > 100)
                AgeRangeEntry.Text = "100";

            if (int.Parse(e.NewTextValue) < 0)
                AgeRangeEntry.Text = "0";

        }
        
    }
}
