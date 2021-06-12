namespace Swagger.ToDo.FSharp

open System.ComponentModel.DataAnnotations

[<CLIMutable>] 
type UserModel = {
    [<Key>] Id : int
    Name : string
}