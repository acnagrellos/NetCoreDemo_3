using ApiStructure.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var projectName = app.Configuration.GetSection("ProjectSettings").GetValue<string>("ProjectName");

var contacts = new List<Contact>();

app.MapGet("/", () => $"Hello {projectName}!");

app.MapGet("/contacts", () => contacts);

app.MapGet("/contacts/{id}", (HttpContext http, int id) =>
{
    var contact = contacts.FirstOrDefault(student => student.Id == id);
    if (contact != null)
    {
        return contact;
    }
    else
    {
        http.Response.StatusCode = 404;
        return null;
    }
});

app.MapPut("/contacts/{id}", (HttpContext http, int id, Contact contactRequest) =>
{
    var contact = contacts.FirstOrDefault(contact => contact.Id == id);
    if (contact != null)
    {
        contacts.Remove(contact);
        contacts.Add(contactRequest);
        return;
    }
    else
    {
        http.Response.StatusCode = 404;
    }
});

app.MapPost("/contacts", (Contact contact) => contacts.Add(contact));

app.MapDelete("/contacts/{id}", (HttpContext http, int id) =>
{
    var student = contacts.FirstOrDefault(student => student.Id == id);
    if (student != null)
    {
        contacts.Remove(student);
    }
    else
    {
        http.Response.StatusCode = 404;
    }
});

app.Run();
