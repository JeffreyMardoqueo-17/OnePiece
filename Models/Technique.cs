using System.Text.Json.Serialization;

    ///   {
    // "id": "int",
    // "name": "string",
    // "translation": "string",
    // "type": "string",
    // "description": "string",
    // "after_ellipsis": "boolean",
    // "luffy_gear":   {
    //    "id": "int",
    //    "name": "string",
    //    "description": "string",
    //    "count_technique": "int"
    //  }
namespace OnePieceWorld.Models
{
    /// <summary>
    /// Representa una técnica utilizada por Luffy, con sus propiedades descriptivas 
    /// y la información correspondiente al gear asociado.
    /// </summary>
    public class Technique
    {
        [JsonPropertyName ("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("translation")]
        public string? Translation { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("after_ellipsis")]
        public bool AfterEllipsis { get; set; }

        [JsonPropertyName("luffy_gear")]
        public LuffyGear? LuffyGear { get; set; }
    }

    /// <summary>
    /// Representa el gear asociado a una técnica, incluyendo detalles 
    /// como el nombre del gear, su descripción y el número de técnicas que contiene.
    /// </summary>
    public class LuffyGear
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("count_technique")]
        public int CountTechnique { get; set; }
    }
}
