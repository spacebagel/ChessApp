using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ChessApp.Pages;

/// <summary>
/// Логика взаимодействия для MainSelectionsPage.xaml
/// </summary>
public partial class MainSelectionsPage : Page
{
    public MainSelectionsPage()
    {
        InitializeComponent();
    }
    private void GetHighestRatedTournament(object sender, RoutedEventArgs e)
    {
        var highestRatedTournament = App.Context.Tournaments
            .Select(t => new
            {
                Tournament = t,
                AverageRating = t.PlayerTours.Average(pt => pt.Player.Rating)
            })
            .OrderByDescending(t => t.AverageRating)
            .FirstOrDefault();

        if (highestRatedTournament != null)
        {
            OutputTextBlock.Text = $"Турнир с самым высоким рейтингом: {highestRatedTournament.Tournament.Id}, Средний рейтинг: {highestRatedTournament.AverageRating}";
        }
        else
        {
            OutputTextBlock.Text = "Не найдено турниров.";
        }
    }

    private void GetHostCountryWinningTournaments(object sender, RoutedEventArgs e)
    {
        var tournaments = App.Context.Tournaments
            .Where(t => t.PlayerTours
                .OrderBy(pt => pt.ResultNumber)
                .Take(3)
                .All(pt => pt.Player.CountryId == t.City.CountryId))
            .ToList();

        var result = new StringBuilder();
        result.AppendLine("Турниры, где все призовые места заняли представители страны-хозяина:");
        foreach (var tournament in tournaments)
        {
            result.AppendLine($"Идентификатор турнира: {tournament.Id}");
        }

        OutputTextBlock.Text = result.ToString();
    }

    private void GetPlayersWithThreeOrMorePrizesIn2000(object sender, RoutedEventArgs e)
    {
        var players = App.Context.Players
            .Where(p => p.PlayerTours.Count(pt => pt.Tour.EventDate.Value.Year == 2000 && pt.ResultNumber <= 3) >= 3)
            .ToList();

        var result = new StringBuilder();
        result.AppendLine("Шахматисты, занявшие не менее трех призовых мест в 2000 году:");
        foreach (var player in players)
        {
            result.AppendLine($"{player.FirstName} {player.LastName}");
        }

        OutputTextBlock.Text = result.ToString();
    }

    private void GetLowestRankedHighestRatedPlayerTournaments(object sender, RoutedEventArgs e)
    {
        var tournaments = App.Context.Tournaments
            .Where(t => t.PlayerTours
                .Any(pt => pt.Player.Rating == t.PlayerTours.Max(p => p.Player.Rating) && pt.ResultNumber == t.PlayerTours.Max(p => p.ResultNumber)))
            .ToList();

        var result = new StringBuilder();
        result.AppendLine("Турниры, где участник с самым высоким рейтингом занял последнее место:");
        foreach (var tournament in tournaments)
        {
            result.AppendLine($"Идентификатор турнира: {tournament.Id}");
        }

        OutputTextBlock.Text = result.ToString();
    }
}