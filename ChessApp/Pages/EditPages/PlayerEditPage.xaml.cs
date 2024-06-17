using ChessApp.Data;
using ChessApp.Methods;
using ChessApp.Models;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace ChessApp.Pages.EditPages;

/// <summary>
/// Логика взаимодействия для PlayerEditPage.xaml
/// </summary>
public partial class PlayerEditPage : Page
{
    public Player? EditPlayer { get; set; } = null;
    private string? imagePath = null;
    byte[]? imageData = null;
    public PlayerEditPage()
    {
        BaseCtorConfig();
    }

    public PlayerEditPage(Player editPlayer)
    {
        EditPlayer = editPlayer;
        DataContext = this;
        imageData = editPlayer.Image;
        BaseCtorConfig();
    }

    private void BaseCtorConfig()
    {
        InitializeComponent();
        var worldChampionStatuses = new List<WorldChampionStatus>
        {
            new WorldChampionStatus { Id = 0, Name = "Не имеет звания чемпиона" },
            new WorldChampionStatus { Id = 1, Name = "Имеет звание чемпиона" }
        };

        cbIsWorldChampion.ItemsSource = worldChampionStatuses;

        if (EditPlayer != null)
        {
            cbCountry.SelectedValue = EditPlayer.CountryId;
            cbSportRank.SelectedValue = EditPlayer.SportRankId;
            cbIsWorldChampion.SelectedValue = EditPlayer.IsWorldChampionContender == true ? 0 : 1;
        }
        cbCountry.ItemsSource = ObservableFromDbModel.CountryCollection;
        cbSportRank.ItemsSource = ObservableFromDbModel.SportRankCollection;
    }

    private void AddBtnClick(object sender, RoutedEventArgs e)
    {

        var isPlayerNull = EditPlayer == null;
        Player currentPlayer = isPlayerNull ? new Player { } : App.Context.Players.First(x => x.Id == EditPlayer.Id);
        currentPlayer.FirstName = tbFirstName.cText;
        currentPlayer.LastName = tbLastName.cText;
        currentPlayer.Note = tbNote.cText;
        currentPlayer.Birthdate = DateOnly.FromDateTime(dpBirthdate.SelectedDate.Value);
        currentPlayer.Rating = Convert.ToInt32(tbRating.cText);
        currentPlayer.CountryId = Convert.ToInt32(cbCountry.SelectedValue);
        currentPlayer.SportRankId = Convert.ToInt32(cbSportRank.SelectedValue);
        currentPlayer.IsWorldChampionContender = cbIsWorldChampion.SelectedIndex == 0 ? false : true;
        if (imagePath != null) imageData = File.ReadAllBytes(imagePath);
        if (imageData != null) currentPlayer.Image = imageData;

        GeneralDbLogic<Player>.AddObjToDb(isPlayerNull, App.Context.Players, currentPlayer, ObservableFromDbModel.PlayerCollection,
            isPlayerNull ? null : ObservableFromDbModel.PlayerCollection.First(x => x.Id == EditPlayer.Id));
    }

    private void GetImageBtnClick(object sender, RoutedEventArgs e)
    {
        OpenFileDialog open = new OpenFileDialog();
        open.Multiselect = false;
        open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
        if (open.ShowDialog() == DialogResult.OK)
        {
            imagePath = open.FileName;
        }
    }

    private void ClearBtnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(EditPlayer == null ? new PlayerEditPage() : new PlayerEditPage(EditPlayer));
}