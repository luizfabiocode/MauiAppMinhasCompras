using MauiAppMinhasCompras.Models;
using SQLite;


namespace MauiAppMinhasCompras.Helpers
{
    public class    SQliteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQliteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> insert(Produto p) 
        {
        return _conn.InsertAsync(p);
        }


        public Task<int> update(Produto p)
        {
            string sql = "UPDATE Produto SET descricao = ?, preco = ?, quantidade = ? WHERE id = ?";
            return _conn.ExecuteAsync(sql, p.Descricao, p.preco, p.Quantidade, p.id);
        }

        public Task<int> delete(Produto p) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.id == p.id);
        }

        public Task<List<Produto>> GetAll() 
        { 
          return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q)

        {
            string sql = "SELECT * produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }






    }
}
