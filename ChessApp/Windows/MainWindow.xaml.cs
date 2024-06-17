using ChessApp.Pages;
using ChessApp.Pages.ViewPages;
using System.Windows;
using System.Windows.Input;

namespace ChessApp.Windows;

/// <summary>
/// Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static Window window;
    public MainWindow()
    {
        InitializeComponent();
        window = this;
        PagesNavigation.Navigate(new PlayerViewPage());
    }
    private void Window_Closed(object sender, EventArgs e) => Application.Current.Shutdown();
    private void btnClose_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

    private void Drag(object sender, RoutedEventArgs e)
    {
        if (Mouse.LeftButton == MouseButtonState.Pressed) window.DragMove();
    }

    private void btnRestore_Click(object sender, RoutedEventArgs e) =>
        WindowState = WindowState == WindowState.Normal ? WindowState = WindowState.Maximized : WindowState = WindowState.Normal;


    private void btnMinimize_Click(object sender, RoutedEventArgs e) =>
        WindowState = WindowState.Minimized;


    private void rbPlayerClick(object sender, RoutedEventArgs e) =>
         PagesNavigation.Navigate(new PlayerViewPage());


    private void rbTourClick(object sender, RoutedEventArgs e) =>
         PagesNavigation.Navigate(new TourViewPage());

    private void rbCityClick(object sender, RoutedEventArgs e) =>
         PagesNavigation.Navigate(new CityViewPage());

    private void rbCountryClick(object sender, RoutedEventArgs e) =>
         PagesNavigation.Navigate(new CountryViewPage());

    private void rbTourLvlClick(object sender, RoutedEventArgs e) =>
         PagesNavigation.Navigate(new TourLvlViewPage());

    private void rbRankCLick(object sender, RoutedEventArgs e) =>
         PagesNavigation.Navigate(new SportRankViewPage());

    private void rbSelectionClick(object sender, RoutedEventArgs e) =>
        PagesNavigation.Navigate(new MainSelectionsPage());


    private void Border_MouseDown_1(object sender, MouseButtonEventArgs e) => Keyboard.ClearFocus();
}