using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Homer.Api.Domain.Entities.Imoveis
{
    [Table("Imovel")]
    public partial class Imovel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public byte[] ImagemCapa { get; set; }
        public List<ImovelImagem> Imagens { get; set; }
    }
}
