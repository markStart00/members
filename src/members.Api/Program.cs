using members.Api.Extensions;
using members.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

/*
if ( builder.Environment.IsDevelopment() ) {
  builder.WebHost.ConfigureKestrel( serverOptions => {
    serverOptions.ListenAnyIP( 5000 );
    serverOptions.ListenAnyIP( 5001, listenOptions =>
      {
        listenOptions.UseHttps( "/https/localhost.pfx", "myPassword" );
      });
  });
}
else {
*/
  builder.WebHost.ConfigureKestrel( serverOptions => {
    serverOptions.ListenAnyIP( 80 );
    serverOptions.ListenAnyIP( 443, listenOptions =>
      {
        listenOptions.UseHttps( "/https/localhost.pfx", "myPassword" );
      });
  });
/*
}
*/
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureApplicationServices(builder.Configuration);

if (builder.Environment.IsDevelopment()) 
{
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else {
		app.UseExceptionHandler("/Error");
		app.UseHsts();
		app.UseHttpsRedirection();
}


app.MapMemberEndpoints();
app.MapHealthChecks("/health");

app.Run();

public partial class Program { }
