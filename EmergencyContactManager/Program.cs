using Application.Handlers.CreateContact;
using Application.Handlers.GetContact;
using Application.Handlers.SearchContact;
using Application.Interfaces.Handlers;
using Application.Interfaces.Services;
using Application.Resolver;
using EmergencyContactManager.Components;
using EmergencyContactManager.Factories;
using Infrastructure.Parsers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<ICreateContactCommandFactory, CreateContactCommandFactory>();
builder.Services.AddScoped<IContactParserResolver, ContactParserResolver>();
builder.Services.AddScoped<IGetContactHandler, GetContactHandler>();
builder.Services.AddScoped<ICreateContactHandler, CreateContactHandler>();
builder.Services.AddScoped<ISearchContactHandler, SearchContactHandler>();
builder.Services.AddScoped<IParsingService, CSVParser>();
builder.Services.AddScoped<IParsingService, JasonParser>();

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    app.UseSwagger();
    app.UseSwaggerUI(); // Swagger UI 실행    
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
