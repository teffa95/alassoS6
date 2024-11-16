using alassoS6.Models;
using System.Net;

namespace alassoS6.Views;

public partial class vActElim : ContentPage
{
    public vActElim(Estudiante datos)
    {
        InitializeComponent();

        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient CLIENTE = new WebClient();
            string url = "http://192.168.1.26/uisraelws/estudiante.php?id={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad.Text}";

            await CLIENTE.UploadStringTaskAsync(new Uri(url), "PUT", ""); // Enviar una solicitud vacía porque los datos van en la URL

            await DisplayAlert("Éxito", "El estudiante ha sido actualizado correctamente", "Cerrar");

            // Navegar de regreso a la vista de estudiantes
            await Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient CLIENTE = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("id", txtCodigo.Text); // Pasar el ID del estudiante como parámetro

            await CLIENTE.UploadValuesTaskAsync(new Uri($"http://192.168.1.26/uisraelws/estudiante.php?id={txtCodigo.Text}"), "DELETE", parametros);

            await DisplayAlert("Éxito", "El estudiante ha sido eliminado correctamente", "Cerrar");

            await Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }
}
