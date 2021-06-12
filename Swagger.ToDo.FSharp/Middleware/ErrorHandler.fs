namespace Swagger.ToDo.FSharp
open System.Text.Json
open System.Threading.Tasks
open Microsoft.AspNetCore.Http

type ErrorHandler(next : RequestDelegate) =
    member this.InvokeAsync (context: HttpContext) : Task =
        async {
            do!
                try
                 next.Invoke context |> Async.AwaitTask
                with
                | ex ->
                    let json = JsonSerializer.Serialize ex.Message
                    context.Response.WriteAsync json |> Async.AwaitTask
        } |> Async.StartAsTask :> Task