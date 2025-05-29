var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.learn_dotnet_react_Server>("server")
                    .WithSwaggerUI()
                    .WithUrlForEndpoint("https", url =>
                    {
                        url.DisplayText = "Swagger (https)";
                        url.Url = "/swagger";
                    })
                    .WithUrlForEndpoint("http", url =>
                    {
                        url.DisplayText = "Swagger";
                        url.Url = "/swagger";
                    });

builder.AddNpmApp("vite", "../learn-dotnet-react.client")
       .WithReference(server)
       .WaitFor(server)
       .WithEnvironment("BROWSER", "none")
       .WithHttpsEndpoint(env: "PORT")
       .WithExternalHttpEndpoints()
       .PublishAsDockerFile();

builder.Build().Run();