using _Configs.Env;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel.Connectors.InMemory;
using OpenAI;
using System.ComponentModel;
using System.Text.Json;

(string model, string endpoint, string apiKey, string embedding, string orgId) = new AzureOpenAIEnvironmentService().GetEnvironmentVariables();


AIAgent agent = new AzureOpenAIClient(
    new Uri(endpoint),
    new AzureCliCredential())
    .GetChatClient(model)
    .CreateAIAgent(new ChatClientAgentOptions
    {
        Name = "Joker",
        Instructions = "You are a helpful assistant that tells jokes.",
        ChatMessageStoreFactory = ctx =>
        {
            return new VectorChatMessageStore(
                new InMemoryVectorStore(),
                ctx.SerializedState,
                ctx.JsonSerializerOptions
                );
        }
    });

AgentThread thread = agent.GetNewThread();

Console.WriteLine(await agent.RunAsync("Tell me a joke about a pirate.", thread));

Console.WriteLine(await agent.RunAsync("Now add some emojis to the joke and tell it in the voice of pirate's parrot", thread));

Console.WriteLine(await agent.RunAsync("Could you repeat what I initially said to you?", thread));

