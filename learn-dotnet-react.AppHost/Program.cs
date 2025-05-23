var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.learn_dotnet_react_Server>("server")
                    .WithExternalHttpEndpoints();

builder.AddNpmApp("vite", "../learn-dotnet-react.client")
       .WithReference(server)
       .WaitFor(server)
       .WithEnvironment("BROWSER", "none")
       .WithHttpEndpoint(env: "VITE_PORT")
       .WithExternalHttpEndpoints()
       .PublishAsDockerFile();

builder.Build().Run();
