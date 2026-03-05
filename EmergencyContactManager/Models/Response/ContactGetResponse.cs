namespace EmergencyContactManager.Models.Response;


public sealed record ContactGetResponse(string Name,
                                    string Email,
                                    string Tel);