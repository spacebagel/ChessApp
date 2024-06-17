using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using ChessApp.Pages.EditPages;
using System.Windows;
using System.Windows.Controls;

namespace ChessApp.Pages.ViewPages;

/// <summary>
/// Логика взаимодействия для SportRankViewPage.xaml
/// </summary>
public partial class SportRankViewPage : Page
{
    public SportRankViewPage()
    {
        InitializeComponent();
        dgSportRank.ItemsSource = ObservableFromDbModel.SportRankCollection;
    }
    private void HouseCBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateList();

    private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) => UpdateList();

    public void UpdateList()
    {
    }
    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new SportRankEditPage());
    }

    private void DeleteBtnClick(object sender, RoutedEventArgs e)
    {
        if (GeneralPageLogic.ConfirmDelete())
            GeneralDbLogic<SportRank>.DeleteObjFromDb(sender, ObservableFromDbModel.SportRankCollection);
    }

    private void EditBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new SportRankEditPage(GeneralDbLogic<SportRank>.TypeFromSender(sender)));
    }
}