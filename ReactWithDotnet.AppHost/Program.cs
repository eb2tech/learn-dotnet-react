var builder = DistributedApplication.CreateBuilder(args);

builder.AddDockerComposeEnvironment("docker-compose");

var weatherApi = builder.AddProject<Projects.ReactWithDotnet_Server>("server");

builder.AddNpmApp("client", "../reactwithdotnet.client")
       .WithReference(weatherApi)
       .WaitFor(weatherApi)
       .WithHttpsEndpoint(env: "VITE_PORT")
       .WithExternalHttpEndpoints()
       .WithOtlpExporter()
       .PublishAsDockerFile();

builder.Build().Run();
