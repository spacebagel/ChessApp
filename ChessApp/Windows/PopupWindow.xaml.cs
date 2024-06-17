using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChessApp.Windows;

/// <summary>
/// Логика взаимодействия для PopupWindow.xaml
/// </summary>
public partial class PopupWindow : Window
{
    public Window window;
    public PopupWindow(Page showPage)
    {
        InitializeComponent();
        PopupPagesNavigation.Navigate(showPage);
        window = this;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e) => Hide();

    private void btnRestore_Click(object sender, RoutedEventArgs e) =>
        WindowState = WindowState == WindowState.Normal ? WindowState = WindowState.Maximized : WindowState = WindowState.Normal;

    private void btnMinimize_Click(object sender, RoutedEventArgs e) =>
        WindowState = WindowState.Minimized;

    private void Border_MouseDown(object sender, MouseButtonEventArgs e) =>
    Keyboard.ClearFocus();

    private void Drag(object sender, MouseButtonEventArgs e)
    {
        if (Mouse.LeftButton == MouseButtonState.Pressed) window.DragMove();
    }
}