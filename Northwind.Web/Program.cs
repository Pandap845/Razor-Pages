


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build(); 
app.MapRazorPages();
app.UseDefaultFiles();
app.UseStaticFiles();




app.MapGet("/", () => "/index");

//Se pueden realizar API (END Points) de manera simple
// el '/' es la raíz.
//A través de una URL se exponen funciones del programa: create, update, delete, and read.
app.Run();
