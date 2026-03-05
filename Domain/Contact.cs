namespace Domain;

public class Contact
{
    private Contact() { }
    public Contact(string name, string email, string tel)
    {
        this.name = name;
        this.email = email;
        this.tel = tel;
    }

    public string name { get; private set; } = default!;
    public string email { get; private set; } = default!;
    public string tel { get; private set; } = default!;
    public DateTimeOffset joined { get; private set; } = DateTimeOffset.UtcNow;
}
