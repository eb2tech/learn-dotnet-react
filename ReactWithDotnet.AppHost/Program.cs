var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ReactWithDotnet_Server>("reactwithdotnet-server");

builder.Build().Run();
