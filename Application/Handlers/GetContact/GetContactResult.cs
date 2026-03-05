namespace Application.Handlers.GetContact;

public sealed record GetContactResult(string Name,
                                           string Email,
                                           string Tel);