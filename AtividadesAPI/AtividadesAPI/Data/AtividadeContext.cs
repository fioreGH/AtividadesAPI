using System.Data;

namespace AtividadesAPI.Data
{
    public class AtividadeContext
    {
        public delegate Task<IDbConnection> GetConnection(); 
    }
}
