using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ChessApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для TourEditPage.xaml
/// </summary>
public partial class TourEditPage : Page
{
    public Tournament? EditTour { get; set; } = null;

    public TourEditPage()
    {
        InitializeComponent();
    }

    public TourEditPage(Tournament editTour)
    {
        EditTour = editTour;
        DataContext = this;
        InitializeComponent();
    }

    private void BaseCtorConfig()
    {
        InitializeComponent();
        if (EditTour != null)
        {
            cbTourLvl.SelectedValue = EditTour.TourLvl;
            cbCity.SelectedValue = EditTour.CityId;
        }
        cbCity.ItemsSource = ObservableFromDbModel.CityCollection;
        cbTourLvl.ItemsSource = ObservableFromDbModel.TourLvlCollection;
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {
        var isTourNull = EditTour == null;

        Tournament currentTour = isTourNull ? new Tournament { } : App.Context.Tournaments.First(x => x.Id == EditTour.Id);
        currentTour.EventDate = DateOnly.FromDateTime(dpEventDate.SelectedDate.Value); ;
        currentTour.CityId = Convert.ToInt32(cbCity.SelectedValue);
        currentTour.TourLvlId = Convert.ToInt32(cbTourLvl.SelectedValue);

        GeneralDbLogic<Tournament>.AddObjToDb(isTourNull, App.Context.Tournaments, currentTour, ObservableFromDbModel.TournamentCollection,
            isTourNull ? null : ObservableFromDbModel.TournamentCollection.First(x => x.Id == EditTour.Id));
    }

    private void ClearBtnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditTour == null ? new TourEditPage() : new TourEditPage(EditTour));
}