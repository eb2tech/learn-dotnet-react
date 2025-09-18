var builder = DistributedApplication.CreateBuilder(args);

builder.AddDockerComposeEnvironment("docker-compose");

var weatherApi = builder.AddProject<Projects.ReactWithDotnet_Server>("server");

builder.AddNpmApp("client", "../reactwithdotnet.client")
       .WithReference(weatherApi)
       .WaitFor(weatherApi)
       //.WithEnvironment("VITE_API_URL", "{weatherApi.http}")
       .WithEnvironment("VITE_GRPC_URL", "{weatherApi.grpc}")
       .WithHttpsEndpoint(env: "VITE_PORT")
       .WithExternalHttpEndpoints()
       .WithOtlpExporter();

builder.Build()
       .Run();
