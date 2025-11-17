Environment Variables

You need to set the following environment variables in your system:



Azure AI

```
[Environment]::SetEnvironmentVariable("AZURE_APIKEY", "sk-YOUR_API_KEY", "User")
[Environment]::SetEnvironmentVariable("AZURE_MODEL", "sk-YOUR_MODELNAME", "User")
[Environment]::SetEnvironmentVariable("AZURE_ENDPOINT", "sk-YOUR_ENDPOINT_", "User")
[Environment]::SetEnvironmentVariable("AZURE_PROJECT", "sk-YOUR_PROJECT", "User")
[Environment]::SetEnvironmentVariable("AZURE_ORGID", "sk-YOUR_ORGID", "User")
[Environment]::SetEnvironmentVariable("AZURE_EMBEDDING", "text-embedding-ada-002", "User")

```

Check if the environment variable is set

```
echo $Env:AZURE_APIKEY

```
