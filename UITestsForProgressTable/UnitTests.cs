using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;
using System.Drawing;
using Color = Avalonia.Media.Color;

namespace UITestsForProgressTable
{
    public class UnitTests
    {
        [Fact]
        public async void Test_Red()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var listBoxItem = listBoxItems.ToArray()[0];
            var visualProgrammBorder = listBoxItem.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammBorder"));
            var textBlockVisualProgramm = listBoxItem.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammText"));
            var text = textBlockVisualProgramm.Text;
            Color c = text switch
            {
                "0" => Colors.Red,
                "1" => Colors.Yellow,
                "2" => Colors.Green,
            };
            var color = (visualProgrammBorder.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");
        }

        [Fact]
        public async void Test_Green()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var listBoxItem = listBoxItems.ToArray()[1];
            var visualProgrammBorder = listBoxItem.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammBorder"));
            var textBlockVisualProgramm = listBoxItem.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammText"));
            var text = textBlockVisualProgramm.Text;
            Color c = text switch
            {
                "0" => Colors.Red,
                "1" => Colors.Yellow,
                "2" => Colors.Green,
            };
            var color = (visualProgrammBorder.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");
        }

        [Fact]
        public async void Test_Yellow()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);
            var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var grid = mainWindow.GetVisualDescendants().OfType<Grid>().First(x => (x.Name != null) && x.Name.Equals("SrGrid"));
            var listBoxItem = listBoxItems.ToArray()[2];
            var visualProgrammBorder = grid.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("VisualSrBorder"));
            var textBlockVisualProgramm = grid.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("VisualSrText"));
            var text = textBlockVisualProgramm.Text;
            Color c = text switch
            {
                "0" => Colors.Red,
                "1" => Colors.Yellow,
                "2" => Colors.Green,
            };
            var color = (visualProgrammBorder.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");
        }

        [Fact]
        public async void student_save_test()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentButton");
            var buttonSave = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveButton");
            var buttonLoad = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "LoadButton");


            buttonSave.Command.Execute(buttonSave.CommandParameter);
            buttonAdd.Command.Execute(buttonAdd.CommandParameter);



            buttonLoad.Command.Execute(buttonLoad.CommandParameter);
            Assert.True(listBoxItems.Count() == 3);
        }
    }
}