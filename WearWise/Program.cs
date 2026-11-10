
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Serve index.html as the default page
app.UseDefaultFiles();

// Enable static files (HTML, CSS, JavaScript, images)
app.UseStaticFiles();

app.Run();
