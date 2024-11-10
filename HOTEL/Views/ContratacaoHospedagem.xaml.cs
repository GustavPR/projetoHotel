namespace HOTEL.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        App PropriedadesApp;

        public ContratacaoHospedagem()
        {
            InitializeComponent();

            // Referência ao objeto Application para acessar as propriedades globais
            PropriedadesApp = (App) Application.Current;
            pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

            // Definindo a data mínima para o check-in como hoje
            dtpck_checkin.MinimumDate = DateTime.Now;

            // Removendo a restrição de MaximumDate, ou definindo um valor futuro mais distante
            // dtpck_checkin.MaximumDate = DateTime.Now.AddYears(1); // Opcional, caso queira permitir 1 ano de antecedência

            // Ajuste inicial do check-out
            dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1); // Não pode ser o mesmo dia
            dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6); // Permitindo até 6 meses após o check-in
        }

        // Método de navegação para página "Sobre"
        private async void OnSobreClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sobre());
        }

        // Evento de clique no botão de confirmação
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new HospedagemContratada());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "Ok");
            }
        }

        // Evento disparado quando a data de check-in é selecionada
        private void dtpck_checkin_DateSelected(object sender, EventArgs e)
        {
            DatePicker elemento = sender as DatePicker;
            DateTime data_selecionada_checkin = elemento.Date;

            // Atualizando as datas de check-out com base na seleção de check-in
            dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1); // Não pode ser o mesmo dia do check-in
            dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6); // Permitindo até 6 meses após o check-in
        }
    }
}

