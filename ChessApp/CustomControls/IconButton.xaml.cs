using System.Windows.Controls;
using System.Windows.Media;

namespace ChessApp.CustomControls;

/// <summary>
/// Логика взаимодействия для IconButton.xaml
/// </summary>
public partial class IconButton : UserControl
{
    public PathGeometry BtnIcon { get; set; }
    public IconButton()
    {
        InitializeComponent();
        DataContext = this;
    }
}