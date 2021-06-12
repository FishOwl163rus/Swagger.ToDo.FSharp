namespace Swagger.ToDo.FSharp

type INoteService =
    abstract member Add: NoteModel -> unit
    abstract member Remove: int -> unit
    abstract member Update: NoteModel -> unit
    abstract member RemoveAll: int -> unit
    abstract member Get: int -> NoteModel
    abstract member GetAll: int -> NoteModel[]
    abstract member GetAll: unit -> NoteModel[]