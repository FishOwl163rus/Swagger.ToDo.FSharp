namespace Swagger.ToDo.FSharp

open System.Data
open Dapper.FSharp
open Dapper.FSharp.MSSQL
open Microsoft.Data.SqlClient

type NoteService() =
    let conn : IDbConnection = new SqlConnection("Server=localhost;Database=todo.root;Trusted_Connection=True;") :> IDbConnection
    
    interface INoteService with
     override this.Add(note) =
         insert {
             table "Notes"
             value note
         } |> conn.InsertAsync |> ignore
         
     override this.Remove(id) =
         delete {
             table "Notes"
             where (eq "Id" id)
         } |> conn.DeleteAsync |> ignore
         
     override this.Update(note) =
         update {
            table "Persons"
            set note
            where (eq "Id" note.Id)
         } |> conn.UpdateAsync |> ignore
         
     override this.RemoveAll(userId) =
         delete {
             table "Notes"
             where (eq "UserId" userId)
         } |> conn.DeleteAsync |> ignore
         
     override this.Get(id) =
         async {
             let! db = (
              select {
                 table "Notes"
                 where (eq "Id" id)
             } |> conn.SelectAsync<NoteModel> |> Async.AwaitTask)
             
             return db |> Seq.cast<NoteModel> |> Seq.head 
         } |> Async.RunSynchronously
        
     override this.GetAll(userId) =
         async {
             let! db = (
              select {
                 table "Notes"
                 where (eq "UserId" userId)
             } |> conn.SelectAsync<NoteModel> |> Async.AwaitTask)
             
             return db |> Seq.cast<NoteModel> |> Seq.toArray
         } |> Async.RunSynchronously
         
     override this.GetAll() =
         async {
             let! db = (
              select {
                 table "Notes"
             } |> conn.SelectAsync<NoteModel> |> Async.AwaitTask)
             
             return db |> Seq.cast<NoteModel> |> Seq.toArray
         } |> Async.RunSynchronously