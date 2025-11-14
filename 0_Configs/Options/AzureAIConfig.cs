using System.ComponentModel.DataAnnotations;

namespace _Configs.Options
{
    /// <summary>
    /// OpenAI service settings.
    /// </summary>
    public  class AzureAIConfig
    {
        public const string ConfigSectionName = "AzureAI";

        [Required]
        public string ModelId { get; set; } = string.Empty;

        [Required]
        public string ApiKey { get; set; } = string.Empty;

        [Required]
        public string Endpoint { get; set; } = null;

        [Required]
        public string Deployment { get; set; } = null;
    }
}
