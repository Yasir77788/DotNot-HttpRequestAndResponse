using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async(HttpContext context) =>
{
    //context.Response.StatusCode = 400;
    context.Response.Headers["MyKey"] = "my value";
    context.Response.Headers["Server"] = "my server";
    //await context.Response.WriteAsync("Hello");
    //await context.Response.WriteAsync(" World");

    string path = context.Request.Path;
    string method = context.Request.Method; 

    context.Response.Headers["Content-Type"] = "text/html";
   // await context.Response.WriteAsync("<h1>This is a html doc</h1>");
   //await context.Response.WriteAsync("<h1>This is another html doc</h1>");
    await context.Response.WriteAsync($"{path}");
    await context.Response.WriteAsync($"<p>{method}</p>");
    // reading an id from a query string
    if (context.Request.Query.ContainsKey("id"))
    {
        string id = context.Request.Query["id"];    
        await context.Response.WriteAsync($"<p>{id}</p>");
    }


});

app.Run();
