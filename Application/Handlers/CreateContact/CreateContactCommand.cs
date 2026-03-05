namespace Application.Handlers.CreateContact;

public sealed record CreateContactCommand(Stream? FileStream,
                                          string? Raw);