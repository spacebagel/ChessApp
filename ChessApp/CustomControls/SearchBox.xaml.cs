using System.Windows;
using System.Windows.Controls;

namespace ChessApp.CustomControls;

/// <summary>
/// Логика взаимодействия для SearchBox.xaml
/// </summary>
public partial class SearchBox : UserControl
{
    public SearchBox()
    {
        InitializeComponent();
    }
    private void SearchBorder_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
    {
        if (SearchItemTxt.Text == "") LblSearchTxt.Visibility = Visibility.Visible;
    }

    private void SearchBorder_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e) =>
        LblSearchTxt.Visibility = Visibility.Hidden;

}