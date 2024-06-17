using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChessApp.CustomControls;

/// <summary>
/// Логика взаимодействия для CuteTextBox.xaml
/// </summary>
public partial class CuteTextBox : UserControl
{
    public string Title { get; set; }

    //public string cText { get; set; }
    public CuteTextBox()
    {
        InitializeComponent();
        DataContext = this;
    }

    public static readonly DependencyProperty cTextProperty =
    DependencyProperty.Register("cText", typeof(string), typeof(CuteTextBox), new UIPropertyMetadata(String.Empty));

    public string cText
    {
        get { return (string)GetValue(cTextProperty); }
        set { SetValue(cTextProperty, value); }
    }

    private void Nametxtbox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        if (TxtBox.Text == "")
        {
            lbl.VerticalAlignment = VerticalAlignment.Center;
            lbl.FontSize = 13;
        }
    }

    private void Nametxtbox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) => SmallTopText();

    private void brdr_Loaded(object sender, RoutedEventArgs e)
    {
        if (TxtBox.Text != "") SmallTopText();
    }

    private void SmallTopText()
    {
        lbl.VerticalAlignment = VerticalAlignment.Top;
        lbl.FontSize = 11;
    }
}