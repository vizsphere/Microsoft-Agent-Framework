using _Configs.Env;

(string model, string endpoint, string apiKey, string embedding, string orgId) = EnvService.ReadFromEnvironment(AISource.OpenAI);
