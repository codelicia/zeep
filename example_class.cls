@TestSetup
public class Foo {
    public string name;

    @AuraEnabled
    global static string methodName() {
        return 'Opa, Claro';
    }
}