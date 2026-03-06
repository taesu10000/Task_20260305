namespace EmergencyContactManager.Models.Response;


public sealed record GetContactListResponse(int Count,
                                            List<GetContactResponse> list);
public sealed record GetContactResponse(string Name,
                                        string Email,
                                        string Tel);