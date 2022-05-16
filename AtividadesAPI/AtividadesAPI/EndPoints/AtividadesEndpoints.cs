using AtividadesAPI.Data;
using Dapper.Contrib.Extensions;
using static AtividadesAPI.Data.AtividadeContext;

namespace AtividadesAPI.EndPoints
{
    public static class AtividadesEndpoints
    {
        public static void MapAtividadesEndpoints(this WebApplication app) 
        {
            app.MapGet("/", () => $"Bem Vindo a API Atividades {DateTime.Now}");

            app.MapGet("/Atividades", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                var atividades = con.GetAll<Atividade>().ToList();

                if (atividades is null)
                    return Results.BadRequest();

                return Results.Ok(atividades);
            
            });
        }
    }
}
