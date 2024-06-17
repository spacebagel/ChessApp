using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ChessApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для CityEditPage.xaml
/// </summary>
public partial class CityEditPage : Page
{
    public City? EditCity { get; set; } = null;
    public CityEditPage()
    {
        BaseCtorConfig();
    }

    public CityEditPage(City editCity)
    {
        EditCity = editCity;
        DataContext = this;
        BaseCtorConfig();
    }

    private void BaseCtorConfig()
    {
        InitializeComponent();
        if (EditCity != null)
        {
            cbCountry.SelectedValue = EditCity.CountryId;
        }
        cbCountry.ItemsSource = ObservableFromDbModel.CountryCollection;
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        var isCityNull = EditCity == null;

        City currentCity = isCityNull ? new City { } : App.Context.Cities.First(x => x.Id == EditCity.Id);
        currentCity.Name = tbName.cText;
        currentCity.CountryId = Convert.ToInt32(cbCountry.SelectedValue);

        GeneralDbLogic<City>.AddObjToDb(isCityNull, App.Context.Cities, currentCity, ObservableFromDbModel.CityCollection,
            isCityNull ? null : ObservableFromDbModel.CityCollection.First(x => x.Id == EditCity.Id));
    }

    private void ClearBtnClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditCity == null ? new CityEditPage() : new CityEditPage(EditCity));
}