

namespace RepMobile.Views;

public class Mes
{
    public int IdMes { get; set; }
    public string Nome { get; set; }
}
enum TipoPonto { E1 = 1, S1, E2, S2 };
public class Pontos
{
    public DateTime Date { get; set; }
    public int tipo { get; set; }
    public string LkpTipo { get => Enum.Parse<TipoPonto>(tipo.ToString()).ToString(); }
}

public class PontoDias
{
    public DateTime Data { get; set; }
    public List<Pontos> Entradas { get; set; }
    public List<Pontos> Saidas { get; set; }
    public List<Pontos> S1{ get; set; }
    public List<Pontos> S2 { get; set; }
}

public partial class Ponto : ContentPage
{
    public List<Mes> Monkeys;// { get; set; }
    public List<Pontos> registros;
    public List<PontoDias> pDias;
    public Ponto()
	{
		InitializeComponent();
        FillPickerPeriodos();

        RefreshRegistro();
    }

    private void RefreshRegistro()
    {
        registros = new List<Pontos>();

        registros.Add(new Pontos() { Date = DateTime.Parse("1/8/2023 08:00"), tipo = (int)TipoPonto.E1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("1/8/2023 08:01"), tipo = (int)TipoPonto.E1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("1/8/2023 08:02"), tipo = (int)TipoPonto.E1 });

        registros.Add(new Pontos() { Date = DateTime.Parse("1/8/2023 12:00"), tipo = (int)TipoPonto.E1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("1/8/2023 13:00"), tipo = (int)TipoPonto.E2 });
        registros.Add(new Pontos() { Date = DateTime.Parse("1/8/2023 17:00"), tipo = (int)TipoPonto.S2 });

        registros.Add(new Pontos() { Date = DateTime.Parse("2/8/2023 08:00"), tipo = (int)TipoPonto.E1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("2/8/2023 12:00"), tipo = (int)TipoPonto.S1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("2/8/2023 13:00"), tipo = (int)TipoPonto.E2 });
        registros.Add(new Pontos() { Date = DateTime.Parse("2/8/2023 17:00"), tipo = (int)TipoPonto.S2 });

        registros.Add(new Pontos() { Date = DateTime.Parse("3/8/2023 08:00"), tipo = (int)TipoPonto.E1 });
        //registros.Add(new Pontos() { Date = DateTime.Parse("3/8/2023 12:00"), tipo = 2 });
        registros.Add(new Pontos() { Date = DateTime.Parse("3/8/2023 13:00"), tipo = (int)TipoPonto.E2 });
        //registros.Add(new Pontos() { Date = DateTime.Parse("3/8/2023 17:00"), tipo = 4 });

        registros.Add(new Pontos() { Date = DateTime.Parse("4/8/2023 15:00"), tipo = (int)TipoPonto.E1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("6/8/2023 17:00"), tipo = (int)TipoPonto.S2 });
        registros.Add(new Pontos() { Date = DateTime.Parse("7/8/2023 17:00"), tipo = (int)TipoPonto.S2 });
        registros.Add(new Pontos() { Date = DateTime.Parse("7/8/2023 17:01"), tipo = (int)TipoPonto.S2 });
        registros.Add(new Pontos() { Date = DateTime.Parse("7/8/2023 17:02"), tipo = (int)TipoPonto.S2 });
        registros.Add(new Pontos() { Date = DateTime.Parse("31/8/2023 17:02"), tipo = (int)TipoPonto.S2 });

        registros.Add(new Pontos() { Date = DateTime.Parse("12/8/2023 08:00"), tipo = (int)TipoPonto.E1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("12/8/2023 12:00"), tipo = (int)TipoPonto.S1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("12/8/2023 13:00"), tipo = (int)TipoPonto.E2 });
        registros.Add(new Pontos() { Date = DateTime.Parse("12/8/2023 17:00"), tipo = (int)TipoPonto.S2 });

        registros.Add(new Pontos() { Date = DateTime.Parse("22/8/2023 08:00"), tipo = (int)TipoPonto.E1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("22/8/2023 12:00"), tipo = (int)TipoPonto.S1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("22/8/2023 13:00"), tipo = (int)TipoPonto.E2 });
        registros.Add(new Pontos() { Date = DateTime.Parse("22/8/2023 17:00"), tipo = (int)TipoPonto.S2 });

        registros.Add(new Pontos() { Date = DateTime.Parse("21/8/2023 08:00"), tipo = (int)TipoPonto.E1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("21/8/2023 12:00"), tipo = (int)TipoPonto.S1 });
        registros.Add(new Pontos() { Date = DateTime.Parse("21/8/2023 13:00"), tipo = (int)TipoPonto.E2 });
        registros.Add(new Pontos() { Date = DateTime.Parse("21/8/2023 17:00"), tipo = (int)TipoPonto.S2 });

        pDias = new List<PontoDias>();
        for (int i = 1; i <= registros.Max(x => x.Date.Day ); i++)
        {
            PontoDias p = new PontoDias { Data = new DateTime(2023, 8, i) };
            p.Entradas = registros.Where(x => x.Date.Day == i && (x.tipo == 1|| x.tipo == 2)).ToList();
            p.Saidas = registros.Where(x => x.Date.Day == i && (x.tipo == 3 || x.tipo == 4)).ToList();

            //p.S1 = registros.Where(x => x.Date.Day == i && x.tipo == 3).ToList();
            //p.S2 = registros.Where(x => x.Date.Day == i && x.tipo == 4).ToList();

            pDias.Add(p);
        }
        LisViewPontos.ItemsSource = null;
        LisViewPontos.ItemsSource = pDias;
    }

    private void FillPickerPeriodos()
    {
        Monkeys = new List<Mes>{
            new Mes() { IdMes=8, Nome="Agosto" },
            new Mes() { IdMes=7, Nome="Julho"}
        };

        PickerDoCapiroto.ItemsSource = Monkeys;
        PickerDoCapiroto.ItemDisplayBinding = new Binding("Nome");
        PickerDoCapiroto.SelectedIndex = 0;

    }

    private void Button_Refresh(object sender, EventArgs e)
    {
        RefreshRegistro();
    }

    private void PickerDoCapiroto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Button_P2(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new P2());
    }
    private void TapGestureRecognizer_ListaPontos(object sender, TappedEventArgs e)
    {

    }
}