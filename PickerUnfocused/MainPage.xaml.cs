using PickerUnfocusedIssueApp.Models;

namespace PickerUnfocused
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Picker_Unfocused
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Picker_Unfocused(object sender, FocusEventArgs e)
		{
			var picker = sender as Picker;
			if (picker != null)
			{
				var selectedCountry = picker.SelectedItem as CountryModel;
				if (selectedCountry != null)
				{
					DisplayAlert("Selected Country", $"You selected: {selectedCountry.Name}", "OK");
				}
			}
		}
	}

}
