using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{   
    public class Contractor
    {
        [Required]
        public int Id { get; set; }

        [Required (ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        public string Fullname { get; set; }

        [Required (ErrorMessage = "Не указан тип организации")]
        public ContractorType? Type {get; set;}

        [Required (ErrorMessage = "Не указан ИНН")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "ИНН должен быть длиной от 10 до 12 символов")]
        public string INN { get; set; }

        [StringLength(9, MinimumLength = 9, ErrorMessage = "КПП должен быть длиной 9 символов")]
        public string KPP { get; set; }

        public enum ContractorType { IP, Сompany }
    }
}
