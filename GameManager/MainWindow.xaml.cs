using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameManager
{
    public partial class MainWindow : Window
    {
        string path = @"C:\Users\SEXTON\Downloads\NecromantiaRisen.rgf";
        public string ScenarioLocation { get; set; }
        public Scenario CurrentScenario { get { return GameFileHandler.Instance.GetScenario(ScenarioLocation); } }

        public MainWindow()
        {
            InitializeComponent();
            ScenarioLocation = "0";
            GameFileHandler.Instance = new GameFileHandler(path);
            Scenario scenario = GameFileHandler.Instance.GetScenario(ScenarioLocation);
            GameTextBlock.Text = CurrentScenario.ResolvedText;
            SetButtons();
        }

        private void SetButtons()
        {
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
            TextBlock1.Text = string.Empty;
            TextBlock2.Text = string.Empty;
            TextBlock3.Text = string.Empty;
            TextBlock4.Text = string.Empty;

            foreach (Choice c in CurrentScenario.Choices)
            {
                (FindName($"Button{c.Number}") as Button).IsEnabled = true;
                (FindName($"TextBlock{c.Number}") as TextBlock).Text = $"{c.Number}) {c.Text}";
            }
        }

        private void IncrementScenario(object val)
        {
            ScenarioLocation = $"{ScenarioLocation}{val}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IncrementScenario((sender as Button).Name.Replace("Button", string.Empty));
            GameTextBlock.Text = CurrentScenario.ResolvedText;
            SetButtons();
        }
    }
}
