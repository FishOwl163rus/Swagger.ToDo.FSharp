namespace Swagger.ToDo.FSharp

open System
open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type NoteModel = {
    [<Key>] Id : int
    Title : string
    Info : string
    EventStart : DateTime
    EventEnd : DateTime
    IsCompleted : bool
    UserId : int
}