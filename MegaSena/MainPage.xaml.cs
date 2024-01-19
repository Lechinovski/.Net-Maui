namespace MegaSena;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnGerarNumbers(object sender, EventArgs e)
    {
        Gerar.IsVisible = false;
        Gerado.IsVisible = true;

        var set = GerarNumbers();

        Num01.Text = set.ElementAt(0).ToString("D2");
        Num02.Text = set.ElementAt(1).ToString("D2");
        Num03.Text = set.ElementAt(2).ToString("D2");
        Num04.Text = set.ElementAt(3).ToString("D2");
        Num05.Text = set.ElementAt(4).ToString("D2");
        Num06.Text = set.ElementAt(5).ToString("D2");
    }

    private SortedSet<int> GerarNumbers()
    {
        var set = new SortedSet<int>();

        while (set.Count < 6)
        {

            var random = new Random();
            var luckNumber = random.Next(1, 60);

            set.Add(luckNumber);
        }

        return set;

    }
}