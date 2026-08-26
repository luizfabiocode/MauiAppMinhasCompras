using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        internal double Preco;

        [PrimaryKey, AutoIncrementAttribute]
        public int id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double preco { get; set; }
    }
}
