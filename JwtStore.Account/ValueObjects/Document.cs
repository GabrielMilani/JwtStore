using JwtStore.Account.Enums;
using JwtStore.Shared.ValueObjects;

namespace JwtStore.Account.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;
    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
}