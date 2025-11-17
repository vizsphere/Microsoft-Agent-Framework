Environment Variables

You need to set the following environment variables in your system:


```
[Environment]::SetEnvironmentVariable("OPEN_AI_APIKEY", "sk-YOUR_API_KEY", "User")
[Environment]::SetEnvironmentVariable("OPEN_AI_MODEL", "sk-YOUR_MODELNAME", "User")
[Environment]::SetEnvironmentVariable("OPEN_AI_ENDPOINT", "sk-YOUR_ENDPOINT_", "User")
[Environment]::SetEnvironmentVariable("OPEN_AI_ORGID", "sk-YOUR_ORGID", "User")
[Environment]::SetEnvironmentVariable("OPEN_AI_EMBEDDING", "text-embedding-ada-002", "User")

```

Azure Open AI

```
[Environment]::SetEnvironmentVariable("AZURE_OPEN_AI_APIKEY", "sk-YOUR_API_KEY", "User")
[Environment]::SetEnvironmentVariable("AZURE_OPEN_AI_MODEL", "sk-YOUR_MODELNAME", "User")
[Environment]::SetEnvironmentVariable("AZURE_OPEN_AI_ENDPOINT", "sk-YOUR_ENDPOINT_", "User")
[Environment]::SetEnvironmentVariable("AZURE_OPEN_AI_PROJECT", "sk-YOUR_PROJECT", "User")
[Environment]::SetEnvironmentVariable("AZURE_OPEN_AI_ORGID", "sk-YOUR_ORGID", "User")
[Environment]::SetEnvironmentVariable("AZURE__OPEN_AI_EMBEDDING", "text-embedding-ada-002", "User")

```

Check if the environment variable is set

```
echo $Env:AZURE_OPEN_AI_APIKEY

```