using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Helpers;
using System.Collections.ObjectModel;
using System.Linq;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    private SQliteDatabaseHelper _db;
    private ObservableCollection<Produto> _todosProdutos = new ObservableCollection<Produto>();
    private ObservableCollection<Produto> _produtosFiltrados = new ObservableCollection<Produto>();

    public ListaProduto()
    {
        InitializeComponent();
        _db = App.Db;  // ⭐ CORRIGIDO: Usa a mesma instância do App
        CarregarProdutos();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarProdutos();
    }

    private async void CarregarProdutos()
    {
        try
        {
            var produtos = await _db.GetAll();
            _todosProdutos = new ObservableCollection<Produto>(produtos);
            _produtosFiltrados = new ObservableCollection<Produto>(produtos);
            CollectionViewProdutos.ItemsSource = _produtosFiltrados;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha ao carregar produtos: {ex.Message}", "OK");
        }
    }

    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string termoBusca = e.NewTextValue?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(termoBusca))
        {
            _produtosFiltrados = new ObservableCollection<Produto>(_todosProdutos);
        }
        else
        {
            var resultados = await _db.Search(termoBusca);
            _produtosFiltrados = new ObservableCollection<Produto>(resultados);
        }

        CollectionViewProdutos.ItemsSource = _produtosFiltrados;
    }

    private async void ToolbarItem_Adicionar_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void ToolbarItem_Somar_Clicked(object sender, EventArgs e)
    {
        if (_todosProdutos != null && _todosProdutos.Any())
        {
            double total = _todosProdutos.Sum(p => p.preco * p.Quantidade);
            await DisplayAlert("Total", $"Valor total das compras: R$ {total:F2}", "OK");
        }
        else
        {
            await DisplayAlert("Total", "Nenhum produto cadastrado", "OK");
        }
    }
}

