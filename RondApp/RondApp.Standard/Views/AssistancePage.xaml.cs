using RondApp.DAL;
using RondApp.Entities;
using RondApp.Managers;
using System;
using System.Collections.Generic;
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
            ResetBtn.Clicked += ResetBtn_Clicked;
        }

      

        private void SearchBtn_Clicked(object sender, EventArgs e)
        {
            NoResultsLbl.IsVisible = false;
            DbCenters db = new DbCenters();
            CentersManager centersMng = new CentersManager(db.GetDatabaseConn());
            
            string origin = OriginPicker.SelectedIndex >= 0 ? HelpValues.Origin.GetValue(OriginPicker.Items[OriginPicker.SelectedIndex]) : "";
            string gender = GenderPicker.SelectedIndex >= 0 ? HelpValues.Gender.GetValue(GenderPicker.Items[GenderPicker.SelectedIndex]) : "";
            string age = !string.IsNullOrWhiteSpace(AgeRangeEntry.Text) ? AgeRangeEntry.Text : "";
            string hygiene = HygienePicker.SelectedIndex >= 0 ? HelpValues.Hygiene.GetValue(HygienePicker.Items[HygienePicker.SelectedIndex]) : "";
            string health = HealthPicker.SelectedIndex >= 0 ? HelpValues.Health.GetValue(HealthPicker.Items[HealthPicker.SelectedIndex]) : "";

            List <CenterDetailed> foundCenters = centersMng.GetByCriteria(origin,gender ,age, hygiene, health);

            if (foundCenters.Count > 0)
                this.Navigation.PushAsync(new CentersList(foundCenters));
            else
                NoResultsLbl.IsVisible = true;

        }
        
        private void AgeRangeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                if (e.NewTextValue.Length > 3)
                {
                    AgeRangeEntry.Text = e.NewTextValue.Substring(0, e.NewTextValue.Length - 2);
                }

                if (int.Parse(e.NewTextValue) > 100)
                {
                    AgeRangeEntry.Text = "";
                }

                if (int.Parse(e.NewTextValue) < 0)
                {
                    AgeRangeEntry.Text = "";
                }

            }
        }

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            OriginPicker.SelectedIndex = -1;
            GenderPicker.SelectedIndex = -1;
            HygienePicker.SelectedIndex = -1;
            HealthPicker.SelectedIndex = -1;
        }
    }
}
