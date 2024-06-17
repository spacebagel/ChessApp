using ChessApp.Windows;
using System.Windows;
using System.Windows.Controls;

namespace ChessApp.Methods;
internal class GeneralPageLogic
{
    public static void OpenPage(Page page) => new PopupWindow(page).Show();

    public static bool ConfirmDelete() => MessageBox.Show("Вы точно хотите удалить выбранный элемент?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
}
