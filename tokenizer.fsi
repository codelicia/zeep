open System

val TokenType : string
// val Token : TokenType option

val splitSpaces : String -> string []
val isEmptyString : string -> bool
val debug : 'a -> unit
// val tokenType : String -> Token

// let nextToken x =
//   match x with
//   | [] -> None
//   | x::_ -> Some (tokenType x)

// // How to I get the previous token
// let rec tokenize text =
//   match text with
//   | [] -> []
//   | x::xs -> ({Current=Some (tokenType x); Next=nextToken xs})::tokenize xs

// let ident x = String.replicate (x * 4) " "

// let render (x: Token option) : unit =
//   match x with
//   | Some {Current=a; Next=_} -> printfn "%A" (Option.get a)
//   | None -> printfn "None"

// val rec output : Int -> Token list -> unit  =
