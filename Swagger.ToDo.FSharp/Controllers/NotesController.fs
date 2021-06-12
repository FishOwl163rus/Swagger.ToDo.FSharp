namespace Swagger.ToDo.FSharp.Controllers

open Microsoft.AspNetCore.Mvc
open Swagger.ToDo.FSharp

[<Route("[controller]/[action]")>]
type NotesController(noteService : INoteService) =
    inherit ControllerBase()
    
    [<HttpPost>]
    member this.Add([<FromBody>]model) = noteService.Add model
    
    [<HttpDelete("{id}")>]
    member this.Remove(id) = noteService.Remove id
    
    [<HttpDelete("{userId}")>]
    member this.RemoveAll(userId) = noteService.RemoveAll userId
    
    [<HttpPut>]
    member this.Update([<FromBody>]model) = noteService.Update model
    
    [<HttpGet("{id}")>]
    member this.Get(id) = noteService.Get id
    
    [<HttpGet("{userId}")>]
    member this.GetAll(userId) = noteService.GetAll userId
    
    [<HttpGet>]
    member this.GetAll() = noteService.GetAll()