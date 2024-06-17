using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ChessApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для SportRankEditPage.xaml
/// </summary>
public partial class SportRankEditPage : Page
{
    public SportRank? EditSportRank { get; set; } = null;

    public SportRankEditPage()
    {
        InitializeComponent();
    }

    public SportRankEditPage(SportRank editSportRank)
    {
        EditSportRank = editSportRank;
        DataContext = this;
        InitializeComponent();
    }
    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        var isSportRankNull = EditSportRank == null;

        SportRank currentSportRank = isSportRankNull ? new SportRank { } : App.Context.SportRanks.First(x => x.Id == EditSportRank.Id);
        currentSportRank.Name = tbName.cText;

        GeneralDbLogic<SportRank>.AddObjToDb(isSportRankNull, App.Context.SportRanks, currentSportRank, ObservableFromDbModel.SportRankCollection,
            isSportRankNull ? null : ObservableFromDbModel.SportRankCollection.First(x => x.Id == EditSportRank.Id));
    }
    private void ClearBtnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditSportRank == null ? new SportRankEditPage() : new SportRankEditPage(EditSportRank));
}