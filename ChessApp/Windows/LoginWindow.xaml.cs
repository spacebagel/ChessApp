using ChessApp.Methods;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace ChessApp.Windows;

/// <summary>
/// Логика взаимодействия для LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    public Window window;
    public LoginWindow()
    {
        InitializeComponent();
        window = this;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

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

    private void AuthBtn_Click(object sender, RoutedEventArgs e)
    {
        if (CryptoLogic.CheckUser(loginTBox.cText, passwordBox.PassBox.Password))
        {
            
            new MainWindow().Show();
            Hide();
        }
        else
        {
            MessageBox.Show("Вход не удался. Проверьте введённые данные!", "Ошибка аутентификации");
        }
    }

    private void SendEmailClick(object sender, MouseButtonEventArgs e)
    {
        string to = "email@email.com";
        string subject = "Запрос на права доступа к системе.";
        string body = "Хочу запросить права на доступ к системе.";

        string mailto = $"mailto:{to}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";

        try
        {
            Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка отправки письма: {0}", ex.ToString());
        }
    }
}