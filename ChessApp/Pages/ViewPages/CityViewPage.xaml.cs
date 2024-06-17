using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using ChessApp.Pages.EditPages;
using System.Windows;
using System.Windows.Controls;

namespace ChessApp.Pages.ViewPages;

/// <summary>
/// Логика взаимодействия для CityViewPage.xaml
/// </summary>
public partial class CityViewPage : Page
{
    public CityViewPage()
    {
        InitializeComponent();
        dgCity.ItemsSource = ObservableFromDbModel.CityCollection;
    }
    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new CityEditPage());
    }
    private void DeleteBtnClick(object sender, RoutedEventArgs e)
    {
        if (GeneralPageLogic.ConfirmDelete())
            GeneralDbLogic<City>.DeleteObjFromDb(sender, ObservableFromDbModel.CityCollection);
    }

    private void EditBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new CityEditPage(GeneralDbLogic<City>.TypeFromSender(sender)));
    }
}