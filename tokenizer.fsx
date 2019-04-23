#r @"./packages/FParsec/lib/net40-client/FParsecCS.dll"
#r @"./packages/FParsec/lib/net40-client/FParsec.dll"

open FParsec

let TClass = pstring "class"
let TPublic = pstring "public"
// let TProtected = pstring "protected"
let TPrivate = pstring "private"
let TGlobal = pstring "global"
let TVisibility = (spaces >>. (TPublic <|> TPrivate <|> TGlobal) .>> spaces)

let TWith = pstring "with"
let TWithout = pstring "without"
let TSharing = pstring "sharing"

let TSharingMode = (spaces >>. ((TWithout <|> TWith) .>> spaces .>> TSharing) .>> spaces)

let str s = pstring s
let floatBetweenBrackets : Parser<float, unit> = str "[" >>. pfloat .>> str "]"

let classParser : Parser<string, unit> = TVisibility >>. TSharingMode .>> TClass .>> spaces

let test p str =
    match run p str with
    | Success(result, _, _)   -> printfn "Success: %A" result
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg

test classParser "public with sharing class Foo {}";;
