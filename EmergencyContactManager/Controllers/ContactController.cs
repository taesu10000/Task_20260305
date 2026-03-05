using Application.Handlers.SearchContact;
using Application.Interfaces.Handlers;
using EmergencyContactManager.Factories;
using EmergencyContactManager.Models.Request;
using EmergencyContactManager.Models.Response;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/employee")]
public class ContactController : ControllerBase
{
    private readonly ICreateContactHandler createContactHandler;
    private readonly IGetContactHandler getContactHandler;
    private readonly ISearchContactHandler searchContactHandler;
    private readonly ICreateContactCommandFactory createContactCommandFactory;

    public ContactController(ICreateContactHandler createContactHandler,
                             IGetContactHandler getContactHandler,
                             ISearchContactHandler searchContactHandler,
                             ICreateContactCommandFactory createContactCommandFactory)
    {
        this.createContactHandler = createContactHandler;
        this.getContactHandler = getContactHandler;
        this.searchContactHandler = searchContactHandler;
        this.createContactCommandFactory = createContactCommandFactory;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(ContactCreateRequest contactCreateRequest, CancellationToken ct)
    {
        var cmd = await createContactCommandFactory.CreateCmdAsync(contactCreateRequest, ct);
        var result = await createContactHandler.ExecuteAsync(cmd, ct);

        return Ok(new ContactCreateResponse(result.affectedCount));
    }
    [HttpGet("{name:string}")]
    public async Task<IActionResult> GetAsync(string name, CancellationToken ct)
    {
        var result = await getContactHandler.ExecuteAsync(name);

        return Ok(new ContactGetResponse(Name: result.Name, Email: result.Email, Tel: result.Tel));
    }
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] int page, int pageSize, CancellationToken ct)
    {
        var query = new SearchContractQuery(page, pageSize);
        var result = await searchContactHandler.ExecuteAsync(query);

        var response = result.Select(r => new ContactGetResponse(Name: r.Name, Email: r.Email, Tel: r.Tel)).ToList();
        return Ok(response);
    }
}
