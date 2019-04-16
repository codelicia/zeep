open System
open System.IO
open System.Text.RegularExpressions

type TokenType =
  | TClass of string
  | TPublic of string
  | TGlobal of string
  | TOpen of string
  | TClose of string
  | TComma of string
  | TLiteral of string
  | TStringType of string
  | TAnnotation of string

type ComplexTokens =
  | TClassDeclaration
  | TPropertyDeclaration

type TClassDeclaration = {
  visibility: string  // option?
  name: string
  annotations: string // list option?
}
// What was I even thinking??????????????????

// type TokenUnit = {
//   tokenType: TokenType;
//   literal: string
// }

// TODO: Do I need to set a context?
type Token = {
  // Before: Option<TokenUnit>
  Current: Option<TokenType>
  Next: Option<TokenType>
}

// TODO: That is really insuficient (o_o ")
let SplitSpaces (line: String) = line.Split(' ')

let isEmptyString x = if x.Equals("") then false else true
let debug x = printfn "%A" x
// let debugToken x = for i in x do printf "%As" i

let tokenType x =
  match x with
  | "class" -> TClass "class"
  | "public" -> TPublic "public"
  | "global" -> TGlobal "global"
  | y when Regex.Match(y,@"^@.+").Success ->
    TAnnotation y
  | "string" -> TStringType "string"
  | "{" -> TOpen "{"
  | "}" -> TClose "}"
  | _ -> TLiteral x

let nextToken x =
  match x with
  | [] -> None
  | x::xs -> Some (tokenType x)

// How to I get the previous token
let rec tokenize text =
  match text with
  | [] -> []
  | x::xs -> ({Current=Some (tokenType x); Next=nextToken xs})::tokenize xs

let ident x = String.replicate (x * 4) " "

let render x =
  match x with
  | Some token -> printf "%A" (Some token::Current)
  | None -> printf "None"

// TODO: It should validate tokens and check syntax
//       altought tokens are valid, the structure can be wrong.
let rec output identationLevel tokens =
  match tokens with
  | [] -> render None
  | x::xs -> render x
  // | (TClass x)::rest -> x + " " + (ident identationLevel)::output identationLevel rest
  // | (TPublic x)::rest -> (ident identationLevel) + x + " "::output identationLevel rest
  // | (TLiteral x)::rest -> x + " "::output identationLevel rest
  // | (TClose x)::rest -> "}\n"::output (identationLevel - 1) rest
  // | (TStringType x)::rest -> x + " "::output identationLevel rest
  // | (TGlobal x)::rest -> (ident identationLevel) + x + " "::output identationLevel rest
  // | (TOpen x)::rest -> "{\n"::output (identationLevel + 1) rest
  // | _::xs -> []


// TODO: refactor
File.ReadAllLines(@"example_class.cls")
  |> Seq.map SplitSpaces
  |> Seq.concat
  |> Seq.filter isEmptyString
  |> Seq.toList
  |> tokenize
  |> output 0
  // |> debug  

