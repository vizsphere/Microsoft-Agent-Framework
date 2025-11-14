using System.ComponentModel.DataAnnotations;

namespace _Configs.Options
{
    /// <summary>
    /// OpenAI service settings.
    /// </summary>
    public  class OpenAIConfig
    {
        public const string ConfigSectionName = "OpenAI";

        [Required]
        public string ModelId { get; set; } = string.Empty;

        [Required]
        public string ApiKey { get; set; } = string.Empty;

        [Required]
        public string? OrgId { get; set; } = null;
    }
}
