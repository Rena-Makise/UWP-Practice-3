using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

public class Library
{
    private const int size = 3;
    private const int win = 1;
    private const int draw = 0;
    private const int lose = -1;
    private int[,] match = new int[size, size]
    {
        { draw, lose, win },
        { win, draw, lose },
        { lose, win, draw }
    };
    private readonly int[] values = new int[] { 0, 1, 2 };
    // Segoe MDL2 Aseets Font의 문자를 통해 각각의 상태(options)를 나타낸다.
    private readonly string[] options = new string[] { "\uED5B", "\uE130", "\uE16B" };
    private readonly Color[] colours = new Color[] { Colors.DarkRed, Colors.DarkBlue, Colors.DarkGreen };

    private Random random = new Random((int)DateTime.Now.Ticks);

    // Dialog를 통해 컴퓨터가 Random함수를 통해 어떤 상태를 선택했는지를 보여준다.
    private async Task<ContentDialogResult> ShowDialogAsync(string title, int option)
    {
        ContentDialog dialog = new ContentDialog()
        {
            Title = title,
            Content = GetShape(option, false),
            PrimaryButtonText = "OK"
        };
        return await dialog.ShowAsync();
    }

    // 컴퓨터가 random함수를 통해 상태(옵션)를 선택하고
    // 플레이어가 선택한 상태(옵션)와 비교하여
    // 이겼는지 졌는지를 판단하여 표시해준다.
    private async void Choose(int option)
    {
        int player = values[option];
        int computer = random.Next(0, size - 1);
        int result = match[player, computer];
        string message = string.Empty;
        switch (result)
        {
            case win:
                message = "You Win!";
                break;
            case lose:
                message = "You Lost";
                break;
            case draw:
                message = "You Draw";
                break;
        }
        await ShowDialogAsync($"Computer Picked - {message}", computer);
    }

    // 상태(옵션)중 하나를 Grid와 TexBlock에 생성하여 반환한다.
    private Grid GetShape(int option, bool useEvent)
    {
        Grid grid = new Grid()
        {
            Tag = option,
            Margin = new Thickness(5),
            Height = 80,
            Width = 80,
            Background = new SolidColorBrush(colours[option]),
        };
        TextBlock text = new TextBlock()
        {
            Text = options[option],
            FontSize = 66,
            FontFamily = new FontFamily("Segoe MDL2 Assets"),
            Foreground = new SolidColorBrush(Colors.White),
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        // useEvent가 true인 경우 선택한 상태(옵션)을 Choose메소드에 전달한다.
        if (useEvent)
        {
            grid.Tapped += (object sender, TappedRoutedEventArgs e) =>
            {
                Grid selected = (Grid)sender;
                int tag = (int)selected.Tag;
                Choose(tag);
            };
        }
        grid.Children.Add(text);
        return grid;
    }

    private void Layout(ref Grid grid)
    {
        grid.Children.Clear();
        StackPanel panel = new StackPanel()
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        for (int i = 0; i < size; i++)
        {
            panel.Children.Add(GetShape(i, true));
        }
        grid.Children.Add(panel);
    }

    public void New(ref Grid grid)
    {
        Layout(ref grid);
    }
}