using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using ChessApp.Pages.EditPages;
using System.Windows;
using System.Windows.Controls;

namespace ChessApp.Pages.ViewPages;

/// <summary>
/// Логика взаимодействия для TourViewPage.xaml
/// </summary>
public partial class TourViewPage : Page
{
    public TourViewPage()
    {
        InitializeComponent();
        dgTour.ItemsSource = ObservableFromDbModel.TournamentCollection;
    }
    private void HouseCBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateList();

    private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) => UpdateList();

    public void UpdateList()
    {
    }
    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new TourEditPage());
    }

    private void DeleteBtnClick(object sender, RoutedEventArgs e)
    {
        if (GeneralPageLogic.ConfirmDelete())
            GeneralDbLogic<Tournament>.DeleteObjFromDb(sender, ObservableFromDbModel.TournamentCollection);
    }

    private void EditBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new TourEditPage(GeneralDbLogic<Tournament>.TypeFromSender(sender)));
    }
}