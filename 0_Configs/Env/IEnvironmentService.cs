using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Configs.Env
{
    public interface IEnvironmentService
    {
        public (string model, string endpoint, string apiKey, string embedding, string orgId) GetEnvironmentVariables();
    }

    public class AzureEnvironmentService : IEnvironmentService
    {
        string _key = "";
        string _model = "";
        string _endpoint = "";
        string _orgId = "";
        string _embedding = "";

        public (string model, string endpoint, string apiKey, string embedding, string orgId) GetEnvironmentVariables()
        {
            _key = Environment.GetEnvironmentVariable("AZURE_APIKEY", EnvironmentVariableTarget.User) ?? "";
            _model = Environment.GetEnvironmentVariable("AZURE_MODEL", EnvironmentVariableTarget.User) ?? "";
            _endpoint = Environment.GetEnvironmentVariable("AZURE_ENDPOINT", EnvironmentVariableTarget.User) ?? "";
            _orgId = Environment.GetEnvironmentVariable("AZURE_ORGID", EnvironmentVariableTarget.User) ?? "";
            _embedding = Environment.GetEnvironmentVariable("AZURE_EMBEDDING", EnvironmentVariableTarget.User) ?? "";

            return (_model, _endpoint, _key, _embedding, _orgId);
        }
    }

    public class AzureOpenAIEnvironmentService : IEnvironmentService
    {
        string _key = "";
        string _model = "";
        string _endpoint = "";
        string _orgId = "";
        string _embedding = "";


        public (string model, string endpoint, string apiKey, string embedding, string orgId) GetEnvironmentVariables()
        {
            _key = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_APIKEY", EnvironmentVariableTarget.User) ?? "";
            _model = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_MODEL", EnvironmentVariableTarget.User) ?? "";
            _endpoint = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_ENDPOINT", EnvironmentVariableTarget.User) ?? "";
            _orgId = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_ORGID", EnvironmentVariableTarget.User) ?? "";
            _embedding = Environment.GetEnvironmentVariable("AZURE_OPEN_AI_EMBEDDING", EnvironmentVariableTarget.User) ?? "";

            return (_model, _endpoint, _key, _embedding, _orgId);
        }
    }

    public class OpenAIEnvironmentService : IEnvironmentService
    {
        string _key = "";
        string _model = "";
        string _endpoint = "";
        string _orgId = "";
        string _embedding = "";

        public (string model, string endpoint, string apiKey, string embedding, string orgId) GetEnvironmentVariables()
        {
            _key = Environment.GetEnvironmentVariable("OPEN_AI_APIKEY", EnvironmentVariableTarget.User) ?? "";
            _model = Environment.GetEnvironmentVariable("OPEN_AI_MODEL", EnvironmentVariableTarget.User) ?? "";
            _endpoint = Environment.GetEnvironmentVariable("OPEN_AI_ENDPOINT", EnvironmentVariableTarget.User) ?? "";
            _orgId = Environment.GetEnvironmentVariable("OPEN_AI_ORGID", EnvironmentVariableTarget.User) ?? "";
            _embedding = Environment.GetEnvironmentVariable("OPEN_AI_EMBEDDING", EnvironmentVariableTarget.User) ?? "";

            return (_model, _endpoint, _key, _embedding, _orgId);
        }
    }

}
