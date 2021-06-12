namespace Swagger.ToDo.FSharp.Interfaces

open Swagger.ToDo.FSharp

type IUserService =
    abstract member Add: UserModel -> unit
    abstract member Remove: int -> unit
    abstract member Update: UserModel -> unit
    abstract member RemoveAll: int -> unit
    abstract member Get: int -> UserModel
    abstract member GetAll: unit -> UserModel[]