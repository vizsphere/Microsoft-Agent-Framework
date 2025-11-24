using Azure.AI.Agents.Persistent;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Agents.AI.Workflows;

(string model, string endpoint) = (Environment.GetEnvironmentVariable("AZURE_MODEL", EnvironmentVariableTarget.User), Environment.GetEnvironmentVariable("AZURE_ENDPOINT", EnvironmentVariableTarget.User));

var persistentAgentsClient = new PersistentAgentsClient(endpoint, new AzureCliCredential());

AIAgent frenchAgent = await GetTranslationAgentAsync("French", persistentAgentsClient, model);
AIAgent englishAgent = await GetTranslationAgentAsync("English", persistentAgentsClient, model);

var workflow = new WorkflowBuilder(englishAgent)
    .AddEdge(englishAgent, frenchAgent)
    .Build();

AIAgent workflowAgent = workflow.AsAgent();

AgentThread thread = workflowAgent.GetNewThread();

Console.WriteLine(await workflowAgent.RunAsync("Greeting users!", thread));

await persistentAgentsClient.Administration.DeleteAgentAsync(frenchAgent.Id);
await persistentAgentsClient.Administration.DeleteAgentAsync(englishAgent.Id);

static async Task<ChatClientAgent> GetTranslationAgentAsync(
           string targetLanguage,
           PersistentAgentsClient persistentAgentsClient,
           string model)
{
    var agentMetadata = await persistentAgentsClient.Administration.CreateAgentAsync(
        model: model,
        name: $"{targetLanguage} Translator",
        instructions: $"You are a translation assistant that translates the provided text to {targetLanguage}.");

    return await persistentAgentsClient.GetAIAgentAsync(agentMetadata.Value.Id);
}