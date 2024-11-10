using Microsoft.Maui.Controls;

namespace HOTEL.Views
{
    public partial class HospedagemContratada : ContentPage
    {
        public HospedagemContratada()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Navigation.NavigationStack.Count > 1)
                {
                    // Pop the current page if there is at least one page in the stack
                    await Navigation.PopAsync();
                }
                else
                {
                    // If there is no previous page, display an alert or handle as needed
                    await DisplayAlert("Info", "Não há página anterior para voltar.", "OK");
                }
            }
            catch (Exception ex)
            {
                // In case of any other error, show a generic error message
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}
