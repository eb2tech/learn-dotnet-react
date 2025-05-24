var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.learn_dotnet_react_Server>("server");

builder.AddNpmApp("vite", "../learn-dotnet-react.client")
       .WithReference(server)
       .WaitFor(server)
       .WithEnvironment("BROWSER", "none")
       .WithHttpEndpoint(env: "PORT")
       .WithExternalHttpEndpoints()
       .PublishAsDockerFile();

builder.Build().Run();
