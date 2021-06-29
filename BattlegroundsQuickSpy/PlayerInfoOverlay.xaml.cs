using System.Windows;
using System.Windows.Controls;

namespace BattlegroundsQuickSpy
{
    public partial class PlayerInfoOverlay : UserControl
    {
        
        public PlayerInfoOverlay()
        {
            InitializeComponent();
            Hide();
        }

        public void Hide()
        {
            Visibility = Visibility.Hidden;
        }

        public void Show()
        {
            Visibility = Visibility.Visible;
        }

        public void Update(int count)
        {
            CountLabel.Text = count.ToString();
        }
    }
}
