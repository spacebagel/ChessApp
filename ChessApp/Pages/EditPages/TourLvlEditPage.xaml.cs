using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ChessApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для TourLvlEditPage.xaml
/// </summary>
public partial class TourLvlEditPage : Page
{
    public TourLvl? EditTourLvl { get; set; } = null;

    public TourLvlEditPage()
    {
        InitializeComponent();
    }

    public TourLvlEditPage(TourLvl editTourLvl)
    {
        EditTourLvl = editTourLvl;
        DataContext = this;
        InitializeComponent();
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        var isTourLvlNull = EditTourLvl == null;

        TourLvl currentTourLvl = isTourLvlNull ? new TourLvl { } : App.Context.TourLvls.First(x => x.Id == EditTourLvl.Id);
        currentTourLvl.Name = tbName.cText;

        GeneralDbLogic<TourLvl>.AddObjToDb(isTourLvlNull, App.Context.TourLvls, currentTourLvl, ObservableFromDbModel.TourLvlCollection,
            isTourLvlNull ? null : ObservableFromDbModel.TourLvlCollection.First(x => x.Id == EditTourLvl.Id));
    }

    private void ClearBtnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditTourLvl == null ? new TourLvlEditPage() : new TourLvlEditPage(EditTourLvl));
}