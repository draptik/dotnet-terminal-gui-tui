namespace MyDemo.Ui.Domain;

public class CoreDomain
{
    public string DoMagic(string s1, string s2)
    {
        return (s1 + s2).ToUpper();
    }
}