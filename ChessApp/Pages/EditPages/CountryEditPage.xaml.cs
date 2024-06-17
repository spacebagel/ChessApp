using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ChessApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для CountryEditPage.xaml
/// </summary>
public partial class CountryEditPage : Page
{
    public Country? EditCountry { get; set; } = null;
    public CountryEditPage()
    {
        InitializeComponent();
    }

    public CountryEditPage(Country editCountry)
    {
        EditCountry = editCountry;
        DataContext = this;
        InitializeComponent();
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        var isCountryNull = EditCountry == null;

        Country currentCountry = isCountryNull ? new Country { } : App.Context.Countries.First(x => x.Id == EditCountry.Id);
        currentCountry.Name = tbName.cText;

        GeneralDbLogic<Country>.AddObjToDb(isCountryNull, App.Context.Countries, currentCountry, ObservableFromDbModel.CountryCollection,
            isCountryNull ? null : ObservableFromDbModel.CountryCollection.First(x => x.Id == EditCountry.Id));
    }

    private void ClearBtnClick(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(EditCountry == null ? new CountryEditPage() : new CountryEditPage(EditCountry));
}