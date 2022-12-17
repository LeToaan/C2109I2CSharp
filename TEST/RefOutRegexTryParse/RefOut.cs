

namespace RefOutRegexTryParse;
internal class RefOut
{
    public static void ChangeVar(out int a,out int b)
    {
        a = 10;
        b = 5;
        var tam = a;
        a=b;
        b = tam;
    }

}
