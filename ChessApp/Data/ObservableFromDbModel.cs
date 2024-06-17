using ChessApp.Models;
using System.Collections.ObjectModel;

namespace ChessApp.Data;

public class ObservableFromDbModel
{
    public static ObservableCollection<Country> CountryCollection = new (App.Context.Countries);
    public static ObservableCollection<City> CityCollection = new (App.Context.Cities);
    public static ObservableCollection<Player> PlayerCollection = new (App.Context.Players);
    public static ObservableCollection<PlayerTour> PlayerTourCollection = new (App.Context.PlayerTours);
    public static ObservableCollection<TourLvl> TourLvlCollection = new (App.Context.TourLvls);
    public static ObservableCollection<Tournament> TournamentCollection = new (App.Context.Tournaments);
    public static ObservableCollection<SportRank> SportRankCollection = new (App.Context.SportRanks);
}
