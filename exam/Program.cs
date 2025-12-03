using UserManagementAPI.Middleware;
using UserManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register User Service
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- ACTIVITY 3: Middleware Pipeline Configuration ---

// 1. Error Handling (Must be first to catch exceptions from all following middleware)
app.UseMiddleware<GlobalExceptionMiddleware>();

// 2. Authentication (Must be before logic to secure endpoints)
app.UseMiddleware<AuthenticationMiddleware>();

// 3. Logging (Logs the request/response details)
app.UseMiddleware<RequestLoggingMiddleware>();

// -----------------------------------------------------

app.MapControllers();

app.Run();