using PickerUnfocusedIssueApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PickerUnfocusedIssueApp.ViewModels
{
    /// <summary>
    /// CountryViewModel
    /// </summary>
    public class CountryViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// countries
        /// </summary>
        private ObservableCollection<CountryModel> _countries;

        /// <summary>
        /// Countries
        /// </summary>
        public ObservableCollection<CountryModel> Countries
        {
            get => _countries;
            set
            {
                if (_countries != value)
                {
                    _countries = value;
                    OnPropertyChanged(nameof(Countries));
                }
            }
        }

        /// <summary>
        /// _selectedCountry
        /// </summary>
        private CountryModel _selectedCountry;

        /// <summary>
        /// SelectedCountry
        /// </summary>
        public CountryModel SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    OnPropertyChanged(nameof(SelectedCountry));
                }
            }
        }

        /// <summary>
        /// CountryViewModel
        /// </summary>
        public CountryViewModel()
        {
            Countries = new ObservableCollection<CountryModel>
            {
                new CountryModel { Name = "United States", Code = "US" },
                new CountryModel { Name = "Canada", Code = "CA" },
                new CountryModel { Name = "United Kingdom", Code = "UK" }
            };
        }

        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
