using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using ChessApp.Pages.EditPages;
using System.Windows;
using System.Windows.Controls;

namespace ChessApp.Pages.ViewPages;

/// <summary>
/// Логика взаимодействия для CountryViewPage.xaml
/// </summary>
public partial class CountryViewPage : Page
{
    public CountryViewPage()
    {
        InitializeComponent();
        dgCountry.ItemsSource = ObservableFromDbModel.CountryCollection;
    }
    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new CountryEditPage());
    }

    private void DeleteBtnClick(object sender, RoutedEventArgs e)
    {
        if (GeneralPageLogic.ConfirmDelete())
            GeneralDbLogic<Country>.DeleteObjFromDb(sender, ObservableFromDbModel.CountryCollection);
    }

    private void EditBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new CountryEditPage(GeneralDbLogic<Country>.TypeFromSender(sender)));
    }
}