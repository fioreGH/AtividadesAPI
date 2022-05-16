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

            app.MapGet("/Atividades/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                /*var atividades = con.Get<Atividade>(id);

                if (atividades is null)
                    return Results.BadRequest();

                return Results.Ok(atividades);*/

                return con.Get<Atividade>(id)  is Atividade atividade ?  Results.Ok(atividade) : Results.BadRequest("Item não encontrado!");

            });

            app.MapPost("/Atividades", async (GetConnection connectionGetter, Atividade Atividade) => 
            {
                using var con = await connectionGetter();
                var id = con.Insert(Atividade);
                return Results.Created($"/Atividade/{id}", Atividade);
            });

            app.MapPut("/Atividades", async (GetConnection connectionGetter, Atividade Atividade) =>
            {
                using var con = await connectionGetter();
                var id = con.Update(Atividade);
                return Results.Ok();
            });

            app.MapDelete("/Atividades/{id}", async (GetConnection connectionGetter, int id) => 
            {
                using var con = await connectionGetter();
                var excluir = con.Get<Atividade>(id);
                if (excluir is null)
                    return Results.NotFound("Item não encontrado!");

                con.Delete(excluir);
                return Results.Ok(excluir);
            });
        }
    }
}
