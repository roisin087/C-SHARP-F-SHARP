#light
open System.Net
open System.IO
open FSharp.Data


let url = "http://localhost:60467//api/contact"

let req = HttpWebRequest.Create(url)

type Json = JsonProvider<"""http://localhost:60467//api/contact""">

let resp = req.GetResponse()

let contacts = Json.GetSamples()

for contact in contacts do
    printfn "#%d %s" contact.Id contact.Name

System.Console.ReadLine()

    













