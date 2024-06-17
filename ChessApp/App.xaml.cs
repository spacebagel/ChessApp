using ChessApp.Data;
using System.Windows;

namespace ChessApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static ChessDbContext Context = new ();
}