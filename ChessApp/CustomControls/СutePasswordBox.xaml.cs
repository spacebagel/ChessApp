using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChessApp.CustomControls;

/// <summary>
/// Логика взаимодействия для СutePasswordBox.xaml
/// </summary>
public partial class СutePasswordBox : UserControl
{
    public string Title { get; set; }
    public СutePasswordBox()
    {
        InitializeComponent();
        DataContext = this;
    }
    private void Nametxtbox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        if (PassBox.Password == "")
        {
            lbl.VerticalAlignment = VerticalAlignment.Center;
            lbl.FontSize = 13;
        }
    }

    private void Nametxtbox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) => SmallTopText();

    private void brdr_Loaded(object sender, RoutedEventArgs e)
    {
        if (PassBox.Password != "") SmallTopText();
    }

    private void SmallTopText()
    {
        lbl.VerticalAlignment = VerticalAlignment.Top;
        lbl.FontSize = 11;
    }
}