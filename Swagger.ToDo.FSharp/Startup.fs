namespace Swagger.ToDo.FSharp

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Dapper.FSharp
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.HttpsPolicy;
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Swagger.ToDo.FSharp.Interfaces

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddControllers() |> ignore
        services.AddSwaggerGen() |> ignore
        
        services.AddScoped<IUserService, UserService>() |> ignore
        services.AddScoped<INoteService, NoteService>() |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseMiddleware<ErrorHandler>() |> ignore
        app.UseSwagger() |> ignore
        
        app.UseSwaggerUI(fun x ->
            x.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo Docs")
            x.RoutePrefix <- "") |> ignore
        
        app.UseHttpsRedirection() |> ignore
        app.UseRouting() |> ignore

        app.UseAuthorization() |> ignore

        app.UseEndpoints(fun endpoints ->
            endpoints.MapControllers() |> ignore
            ) |> ignore
        
        OptionTypes.register()

    member val Configuration : IConfiguration = null with get, set
