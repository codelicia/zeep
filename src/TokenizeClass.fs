(*

    It shold allow for the following structure to be used: 

    private | public | global 
    [virtual | abstract | with sharing | without sharing] 
    class ClassName [implements InterfaceNameList] [extends ClassName] 
    { 
        // The body of the class
    }

    @see https://developer.salesforce.com/docs/atlas.en-us.apexcode.meta/apexcode/apex_classes_defining.htm
*)

// open FParsec

// let TClass = pstring "class"
// let TPublic = pstring "public"
// let TProtected = pstring "protected"
// let TPrivate = pstring "private"
// let TVisibility = (spaces >>. (TPublic <|> TProtected <|> TPrivate) .>> spaces)
