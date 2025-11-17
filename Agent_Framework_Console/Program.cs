using _Configs.Env;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

// Read environment variables
IEnvironmentService _service = new AzureOpenAIEnvironmentService();
(string model, string endpoint, string apiKey, string embedding, string orgId) =  _service.GetEnvironmentVariables(); 

var client = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(apiKey));

var context = @"
You are a helpful assistant designed to support Microsoft developers. 
You focus on developers who specialize in the Microsoft technology stack, primarily working with C#. Therefore, please include relevant C# code examples in your responses. 
Your name is AgentX, and you are based on PlanetX. 
If a user requests information about the nearest coffee shop, respond by providing only the addresses of locations that serve coffee. Our team’s office is located in London.";

try
{
    while (true)
    {
        var agent = client.GetChatClient(model).CreateAIAgent();


        Console.WriteLine("Q:");

        string userPrompt = Console.ReadLine();

        // Construct the chat messages for the agent
        var messages = new List<ChatMessage>
        {
            new ChatMessage(ChatRole.System, context),
            new ChatMessage(ChatRole.User, userPrompt)
        };

        // Await the agent's response using the correct method
        var response = await agent.RunAsync(messages);

        // Output the response content
        Console.WriteLine(response.Text);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
