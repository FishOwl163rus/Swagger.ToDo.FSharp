namespace Swagger.ToDo.FSharp

open System.Data
open Dapper.FSharp
open Dapper.FSharp.MSSQL
open Microsoft.Data.SqlClient
open Swagger.ToDo.FSharp.Interfaces


type UserService() =
    let conn : IDbConnection = new SqlConnection("Server=localhost;Database=todo.root;Trusted_Connection=True;") :> IDbConnection
    
    interface IUserService with
     override this.Add(model) =
         insert {
             table "Users"
             value model
         } |> conn.InsertAsync |> ignore
         
     override this.Remove(id) =
         delete {
             table "Users"
             where (eq "Id" id)
         } |> conn.DeleteAsync |> ignore
         
     override this.Update(model) =
         update {
            table "Users"
            set model
            where (eq "Id" model.Id)
         } |> conn.UpdateAsync |> ignore
     override this.RemoveAll(userId) =
         delete {
             table "Users"
             where (eq "Id" userId)
         } |> conn.DeleteAsync |> ignore
         
     override this.Get(userId) =
         async {
             let! db = (
              select {
                 table "Users"
                 where (eq "Id" userId)
             } |> conn.SelectAsync<UserModel> |> Async.AwaitTask)
             
             return db |> Seq.cast<UserModel> |> Seq.head 
         } |> Async.RunSynchronously
         
     override this.GetAll() =
         async {
             let! db = (
              select {
                 table "Users"
             } |> conn.SelectAsync<UserModel> |> Async.AwaitTask)
             
             return db |> Seq.cast<UserModel> |> Seq.toArray
         } |> Async.RunSynchronously