using System.Timers;
namespace RepMobile.Views;

public partial class P2 : ContentPage
{
    static List<Pontos> db = new List<Pontos>();

    public P2()
    {
        InitializeComponent();
        RefreshRegistro();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        DateTime now = DateTime.Now;

        labelDataEDia.Text = string.Format("{0:dd/MM/yyyy} {0:ddd}", now);
        labelRelogio.Text = DateTime.Now.ToString("HH:mm:ss");

        Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            labelDataEDia.Text = string.Format("{0:dd/MM/yyyy} {0:ddd}", now);
            labelRelogio.Text = DateTime.Now.ToString("HH:mm:ss");
            return true;
        });

        Application.Current.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(1), () =>
        {
            return true;
        });

    }

    private async void LabelBatida_RegistrarPonto(object sender, TappedEventArgs e)
    {
        string[] strTipoPontos = new string[] { "Primeira Entrada", "Primeira Saída", "Segunda Entrada", "Segunda Saída" };

        TipoPonto tipoPonto = Enum.Parse<TipoPonto>((string)e.Parameter);
        //if(tipoPonto)
        int iPonto = (int)tipoPonto;

        if (iPonto - 1 < strTipoPontos.Length && ( !string.IsNullOrEmpty(strTipoPontos[iPonto - 1])))
        {
            if (await App.Current.MainPage.DisplayAlert("Aviso", $"Deseja Registrar a {strTipoPontos[(int)tipoPonto - 1]}?", "Sim", "Nao"))
            {
                if (db.Where(x => x.tipo == (int)tipoPonto).Count() > 0)
                    if (!await App.Current.MainPage.DisplayAlert("Aviso", "Ja existe(m) registro(s)!\n\rDeseja prosseguir?", "Sim", "Nao"))
                        return;
                
                RegistrarPonto(tipoPonto);
            }
        }
    }

    private void RegistrarPonto(TipoPonto tipoPonto)
    {
        db.Add(new Pontos { Date = DateTime.Now, tipo = (int)tipoPonto });
        RefreshRegistro();
    }

    private void RefreshRegistro()
    {
        cVRegistroE1.ItemsSource = db.Where(x => x.tipo == (int)TipoPonto.E1);
        cVRegistroS1.ItemsSource = db.Where(x => x.tipo == (int)TipoPonto.S1);
        cVRegistroE2.ItemsSource = db.Where(x => x.tipo == (int)TipoPonto.E2);
        cVRegistroS2.ItemsSource = db.Where(x => x.tipo == (int)TipoPonto.S2);
    }

    private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {
        ((Border)sender).BackgroundColor = ((Border)sender).BackgroundColor.WithAlpha(0.8f);
    }

    private void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    {
        ((Border)sender).BackgroundColor = ((Border)sender).BackgroundColor.WithAlpha(1f);
    }
}