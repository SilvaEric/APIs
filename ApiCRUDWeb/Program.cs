using ApiCRUDWeb.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/Users", (AppDbContext context) => {
	var users = context.Users.ToList();
	return Results.Ok(users);
});

app.Run();
