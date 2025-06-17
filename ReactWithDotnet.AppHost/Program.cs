var builder = DistributedApplication.CreateBuilder(args);

var weatherApi = builder.AddProject<Projects.ReactWithDotnet_Server>("server")
                        .WithExternalHttpEndpoints();

builder.AddNpmApp("client", "../reactwithdotnet.client")
       .WithReference(weatherApi)
       .WaitFor(weatherApi)
       .WithHttpsEndpoint(env: "PORT")
       .WithExternalHttpEndpoints()
       .PublishAsDockerFile();

builder.Build().Run();
