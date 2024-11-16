using alassoS6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace alassoS6.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://192.168.1.26/uisraelws/estudiante.php";
	private readonly HttpClient client = new HttpClient();
	private ObservableCollection<Estudiante> estud;
	public vEstudiante()
	{
		InitializeComponent();
		mostrar();
	}

	public async void mostrar()
	{
        try
        {
            var content = await client.GetStringAsync(Url);
            List<Estudiante> mostarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
            estud = new ObservableCollection<Estudiante>(mostarEst);
            lvEstudiantes.ItemsSource = estud;
        }
        catch (HttpRequestException ex)
        {
            await DisplayAlert("Error", $"Error al obtener datos: {ex.Message}", "OK");
        }
        catch (JsonException ex)
        {
            await DisplayAlert("Error", $"Error al procesar datos: {ex.Message}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ha ocurrido un error: {ex.Message}", "OK");
        }
    }

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vInsertar());
    }

    private void lvEstudiantes_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vActElim(objEstudiante));
    }
}

