using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Floralia_API.ViewModels
{
    public class UsuarioViewModel
    {

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        //ignora qualquer json pois sera preciso apenas dcaptar a imagem
        [NotMapped]
        [JsonIgnore]
        //É preciso de uma prop do tipo iformfile
        public IFormFile? File { get; set; }
        public string? Foto { get; set; }
    }
}
