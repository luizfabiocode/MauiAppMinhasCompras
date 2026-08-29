using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    // ⭐ CORRIGIDO: Adicionado 'async' e 'await' no DisplayAlert
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_descriçao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                preco = Convert.ToDouble(txt_preco.Text)  // ⭐ CORRIGIDO: 'preco' minúsculo (igual ao modelo)
            };

            await App.Db.insert(p);
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

            // ⭐ NOVO: Limpar os campos após salvar
            txt_descriçao.Text = "";
            txt_quantidade.Text = "";
            txt_preco.Text = "";
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
