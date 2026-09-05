using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

	private async void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		try
		{
			Produto produto_anexado = BindingContext as Produto;
			Produto p = new Produto
			{
				id = produto_anexado.id,
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				preco = Convert.ToDouble(txt_preco.Text)
			};

			await App.Db.update(p);
			await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
			await Navigation.PopAsync();


			txt_descricao.Text = "";
			txt_quantidade.Text = "";
			txt_preco.Text = "";
		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}
	}
}

