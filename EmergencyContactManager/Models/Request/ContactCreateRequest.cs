namespace EmergencyContactManager.Models.Request;

public sealed record ContactCreateRequest(IFormFile? File,
                                          string? Raw);