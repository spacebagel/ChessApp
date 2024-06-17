using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using ChessApp.Pages.EditPages;
using System.Windows;
using System.Windows.Controls;

namespace ChessApp.Pages.ViewPages;

/// <summary>
/// Логика взаимодействия для PlayerViewPage.xaml
/// </summary>
public partial class PlayerViewPage : Page
{
    public PlayerViewPage()
    {
        InitializeComponent();
        viewList.ItemsSource = ObservableFromDbModel.PlayerCollection;
    }

    private void DeleteBtnClick(object sender, RoutedEventArgs e)
    {
        if (GeneralPageLogic.ConfirmDelete())
            GeneralDbLogic<Player>.DeleteObjFromDb(sender, ObservableFromDbModel.PlayerCollection);
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new PlayerEditPage());
    }


    private void EditBtnClick(object sender, RoutedEventArgs e)
    {
        GeneralPageLogic.OpenPage(new PlayerEditPage(GeneralDbLogic<Player>.TypeFromSender(sender)));
    }

    private void KeyDownSearchBox(object sender, System.Windows.Input.KeyEventArgs e)
    {
        var searchText = tbSearch.SearchItemTxt.Text;
        if (searchText != string.Empty)
            viewList.ItemsSource = ObservableFromDbModel.PlayerCollection.Where(x => x.FirstName.Contains(searchText, StringComparison.OrdinalIgnoreCase)
            || x.LastName.Contains(searchText, StringComparison.OrdinalIgnoreCase));
        else viewList.ItemsSource = ObservableFromDbModel.PlayerCollection;
    }
}