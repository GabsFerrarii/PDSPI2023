using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
{
    public class Produto
    {
        [DisplayName("Id")]
        public long ProdutoId { get; set; }
        public string Nome { get; set; }
        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "Informe a data de cadastro do produto")]
        public DateTime DataCadastro { get; set; }
        [DisplayName("Categoria")]
        public long? CategoriaId { get; set; }
        [DisplayName("Fabricante")]
        public long? FabricanteId { get; set; }
        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
        public string NomeArquivo { get; set; }
        public long TamanhoArquivo { get; set; }
        public string LogotipoMimeType { get; set; }
        public byte[] Logotipo { get; set; }
    }
}