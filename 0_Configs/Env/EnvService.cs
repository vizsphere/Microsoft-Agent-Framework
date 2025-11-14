using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Configs.Env
{
    public class EnvService
    {
        public static (string model, string endpoint, string apiKey, string embedding, string orgId) ReadFromEnvironment(AISource settingOption)
        {
            string _key = "";
            string _model = "";
            string _endpoint = "";
            string _orgId = "";
            string _embedding = "";

            if (settingOption == AISource.Azure)
            {
                _key = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_APIKEY", EnvironmentVariableTarget.User) ?? "";
                _model = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_MODEL", EnvironmentVariableTarget.User) ?? "";
                _endpoint = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_ENDPOINT", EnvironmentVariableTarget.User) ?? "";
                _orgId = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_ORGID", EnvironmentVariableTarget.User) ?? "";
                _embedding = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_EMBEDDING", EnvironmentVariableTarget.User) ?? "";
            }
            else if (settingOption == AISource.OpenAI)
            {
                _key = Environment.GetEnvironmentVariable("OPEN_AI_APIKEY", EnvironmentVariableTarget.User) ?? "";
                _model = Environment.GetEnvironmentVariable("OPEN_AI_MODEL", EnvironmentVariableTarget.User) ?? "";
                _endpoint = Environment.GetEnvironmentVariable("OPEN_AI_ENDPOINT", EnvironmentVariableTarget.User) ?? "";
                _orgId = Environment.GetEnvironmentVariable("OPEN_AI_ORGID", EnvironmentVariableTarget.User) ?? "";
                _embedding = Environment.GetEnvironmentVariable("OPEN_AI_EMBEDDING", EnvironmentVariableTarget.User) ?? "";

            }

           return (_model, _endpoint, _key, _embedding, _orgId);
        }
    }
}
