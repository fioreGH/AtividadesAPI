using System.ComponentModel.DataAnnotations.Schema;

namespace AtividadesAPI.Data;

[Table("Atividades")]
public record Atividade(int Id, string Tarefas, string Status);



