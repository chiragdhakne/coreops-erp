using CoreOpsERP.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// -------------------------
// Service Registration
// -------------------------

builder.Services.AddControllers();

// Swagger (for testing)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------------
// Build App
// -------------------------

var app = builder.Build();

// -------------------------
// Middleware Pipeline
// -------------------------

// Global Exception Middleware (FIRST)
app.UseMiddleware<GlobalExceptionMiddleware>();

// Swagger (dev only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// (Auth will come later)
// app.UseAuthentication();
app.UseAuthorization();

// Map Controllers
app.MapControllers();

// -------------------------
// Run App
// -------------------------

app.Run();