var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.learn_dotnet_react_Server>("learn-dotnet-react-server");

builder.Build().Run();
