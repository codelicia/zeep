open System
open System.IO

type Token =
  | TClass of string
  | TPublic of string
  | TGlobal of string
  | TOpen of string
  | TClose of string
  | TComma of string
  | TLiteral of string
  | TStringType of string
  | TAnnotation of string

let SplitSpaces (line: String) = line.Split [|' '|]

let isEmptyString x = if x.Equals("") then false else true
let debug x = for i in x do printf "%s" i

let rec tokenize text =
  match text with
  | [] -> []
  | "class"::rest -> (TClass "class")::tokenize rest
  | "public"::rest -> (TPublic "public")::tokenize rest
  | "{"::rest -> (TOpen "{")::tokenize rest
  | "}"::rest -> (TClose "}")::tokenize rest
  | "string"::rest -> (TStringType "string")::tokenize rest
  | "@TestSetup"::rest -> (TAnnotation "@TestSetup")::tokenize rest
  | x::rest -> (TLiteral x)::tokenize rest

// TODO: Add identation level here
let rec output identationLevel tokens =
  match tokens with
  | [] -> []
  | (TAnnotation x)::rest -> x + "\n"::output identationLevel rest
  | (TClass x)::rest -> x + " "::output identationLevel rest
  | (TPublic x)::rest -> x + " "::output identationLevel rest
  | (TLiteral x)::rest -> x + " "::output identationLevel rest
  | (TClose x)::rest -> "}\n"::output (identationLevel - 1) rest
  | (TGlobal x)::rest -> x + " "::output identationLevel rest
  | (TOpen x)::rest -> "{\n"::output (identationLevel + 1) rest
  | _::rest -> ""::output identationLevel rest

File.ReadAllLines(@"example_class.cls")
  |> Seq.map SplitSpaces
  |> Seq.concat
  |> Seq.filter isEmptyString
  |> Seq.toList
  |> tokenize
  |> output 0
  // |> Seq.concat
  |> debug

