using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Configs.Options
{
    public class BingSearchConfig
    {
        public const string ConfigSectionName = "BingSearch";

        [Required]
        public string ApiKey { get; set; } = string.Empty;
    }
}
