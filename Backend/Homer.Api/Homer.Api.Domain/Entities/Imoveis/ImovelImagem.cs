using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homer.Api.Domain.Entities.Imoveis
{
    [Table("ImovelImagem")]
    public partial class ImovelImagem
    {
        [Key]
        public int Id { get; set; }
        public int ImovelId { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
    }
}
