var builder = DistributedApplication.CreateBuilder(args);

var weatherApi = builder.AddProject<Projects.ReactWithDotnet_Server>("server")
                        .WithExternalHttpEndpoints();

builder.AddNpmApp("client", "../reactwithdotnet.client")
       .WithReference(weatherApi)
       .WaitFor(weatherApi)
       .WithHttpsEndpoint(env: "VITE_PORT")
       .WithExternalHttpEndpoints()
       .PublishAsDockerFile();

builder.Build().Run();
