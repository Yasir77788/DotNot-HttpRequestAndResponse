using Microsoft.Extensions.Primitives;
using System.Security.Cryptography;
using System.IO;

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
    // use parsing to convert string query format to dictionary format
    // reading body from HTTP POST method
    // create a reader
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict =
    Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    

});

app.Run();
