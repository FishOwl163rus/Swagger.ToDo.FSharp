namespace Swagger.ToDo.FSharp.Controllers

open Microsoft.AspNetCore.Mvc
open Swagger.ToDo.FSharp.Interfaces

[<Route("[controller]/[action]")>]
type UsersController(userService : IUserService) =
    inherit ControllerBase()
    
    [<HttpPost>]
    member this.Add([<FromBody>]model) = userService.Add model
    
    [<HttpDelete("{id}")>]
    member this.Remove(id) = userService.Remove id
    
    [<HttpDelete("{userId}")>]
    member this.RemoveAll(userId) = userService.RemoveAll userId
    
    [<HttpPut>]
    member this.Update([<FromBody>]model) = userService.Update model
    
    [<HttpGet("{id}")>]
    member this.Get(id) = userService.Get id
    
    [<HttpGet>]
    member this.GetAll() = userService.GetAll()