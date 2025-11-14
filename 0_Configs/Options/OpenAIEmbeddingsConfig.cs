using System.ComponentModel.DataAnnotations;

namespace _Configs.Options
{
    /// <summary>
    /// OpenAI Embeddings service settings.
    /// </summary>
    public class OpenAIEmbeddingsConfig
    {
        public const string ConfigSectionName = "OpenAIEmbeddings";

        [Required]
        public string ModelId { get; set; } = string.Empty;

        [Required]
        public string ApiKey { get; set; } = string.Empty;

        [Required]
        public string? OrgId { get; set; } = null;
    }
}
