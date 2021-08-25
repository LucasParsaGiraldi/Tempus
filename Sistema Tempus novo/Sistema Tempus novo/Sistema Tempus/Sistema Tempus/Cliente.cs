namespace Sistema_Tempus
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [Key]
        public int Cliente_ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data_Nascimento { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data_Cadastro { get; set; }

        public decimal? Renda_Familiar { get; set; }
    }
}
