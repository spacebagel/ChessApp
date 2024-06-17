using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using ChessApp.Pages.EditPages;
using System.Windows;
using System.Windows.Controls;

namespace ChessApp.Pages.ViewPages;

/// <summary>
/// Логика взаимодействия для TourLvlViewPage.xaml
/// </summary>
public partial class TourLvlViewPage : Page
{
    public TourLvlViewPage()
    {
        InitializeComponent();
        dgTourLvl.ItemsSource = ObservableFromDbModel.TourLvlCollection;
    }
    private void HouseCBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateList();

    private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) => UpdateList();

    public void UpdateList()
    {
    }
    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new TourLvlEditPage());
    }

    private void DeleteBtnClick(object sender, RoutedEventArgs e)
    {
        if (GeneralPageLogic.ConfirmDelete())
            GeneralDbLogic<TourLvl>.DeleteObjFromDb(sender, ObservableFromDbModel.TourLvlCollection);
    }

    private void EditBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new TourLvlEditPage(GeneralDbLogic<TourLvl>.TypeFromSender(sender)));
    }
}