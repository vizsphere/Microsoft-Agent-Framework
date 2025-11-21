using _Configs.Env;
using Agent_Framework.Model;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI;
using OpenTelemetry;
using OpenTelemetry.Trace;
using System.ComponentModel;
using System.Text.Json;

///<summary>
///https://learn.microsoft.com/en-us/agent-framework/tutorials/agents/function-tools-approvals?pivots=programming-language-csharp
///</summary>

#pragma warning disable MEAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
(string model, string endpoint, string apiKey, string embedding, string orgId) = new AzureOpenAIEnvironmentService().GetEnvironmentVariables();

using var traceProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("agent-telemetry")
    .AddConsoleExporter()
    .Build();

AIFunction speakerFunction = AIFunctionFactory.Create(GetSpeaker);

AIFunction approveRequiredSpeakerFunction = new ApprovalRequiredAIFunction(speakerFunction);

AIAgent agent = new AzureOpenAIClient(
    new Uri(endpoint),
    new AzureCliCredential())
    .GetChatClient(model)
    .CreateAIAgent(
        instructions: "You are a helpful assistant.",
        tools: [AIFunctionFactory.Create(GetSpeaker), approveRequiredSpeakerFunction])
    .AsBuilder()
    .UseOpenTelemetry(sourceName: "agent-telemetry")
    .Build();

AgentThread thread = agent.GetNewThread();

Console.WriteLine(await agent.RunAsync("Tell me a joke about a pirate.", thread));

Console.WriteLine(await agent.RunAsync("Now add some emojis to the joke and tell it in the voice of pirate's parrot", thread));

AgentRunResponse speakerResponse = await agent.RunAsync("Get me information about a random motivational speaker.", thread);

var functionApprovalRequests = speakerResponse.Messages
                               .SelectMany(x => x.Contents)
                               .OfType<FunctionApprovalRequestContent>()
                               .ToList();

FunctionApprovalRequestContent requestContent = functionApprovalRequests.First();

Console.WriteLine($"Function Approval Requests:{requestContent.FunctionCall.Name}");

var approvalMessage = new ChatMessage(ChatRole.User, [requestContent.CreateResponse(true)]);

Console.WriteLine(await agent.RunAsync(approvalMessage));

AIAgent visionAgent = new AzureOpenAIClient(
    new Uri(endpoint),
    new AzureCliCredential())
        .GetChatClient(model)
        .CreateAIAgent(name: "VisionAgent", instructions: "You are helpful agent that can analyze images"
    );

ChatMessage chatMessage = new(ChatRole.User, [
        new TextContent("Describe the content of this image:"),
        new UriContent("https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg", "image/jpeg")
    ]);

Console.WriteLine(await visionAgent.RunAsync(chatMessage));


[Description("Get random speaker information.")]
static Speaker GetSpeaker()
{
    var speakers = new List<Speaker>()
    {
        new Speaker() { Id = 1, Name = "Dave Ramsey", Bio = "Financial author and motivational speaker.", WebSite = "http://www.daveramsey.com" },
        new Speaker() { Id = 2, Name = "Tony Robbins", Bio = "Motivational speaker and self-help author.", WebSite = "http://www.tonyrobbins.com" },
        new Speaker() { Id = 3, Name = "Nick Vujicic", Bio = "Christian evangelist and motivational speaker.", WebSite = "http://www.nickvujicic.com" },
        new Speaker() { Id = 4, Name = "Eckhart Tolle", Bio = "Author of The Power of Now.", WebSite = "http://www.eckharttolle.com" },
        new Speaker() { Id = 5, Name = "Louise Hay", Bio = "Motivational author and founder of Hay House.", WebSite = "http://www.louisehay.com" },
        new Speaker() { Id = 6, Name = "Chris Gardner", Bio = "Entrepreneur and motivational speaker.", WebSite = "http://www.chrisgardnermedia.com" },
        new Speaker() { Id = 7, Name = "Robert Kiyosaki", Bio = "Businessman and financial literacy activist.", WebSite = "http://www.richdad.com" }
    };
    Random rand = new();
    int index = rand.Next(speakers.Count);
    return speakers[index];
}