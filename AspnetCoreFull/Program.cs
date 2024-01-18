using AspnetCoreFull.Data;
using AspnetCoreFull.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure DbContext
builder.Services.AddDbContext<AnalyticaContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AnalyticaContext") ??
                       throw new InvalidOperationException("Connection string 'AnalyticaContext' not found.")));

// Configure Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
  .AddEntityFrameworkStores<AnalyticaContext>();

// Configure login path
builder.Services.ConfigureApplicationCookie(options =>
{
  options.LoginPath = "/Auth/Login/Cover";
});

// Add helper service
builder.Services.AddScoped<AnimalService>();

// Add developer exception page filter for database-related exceptions
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// pred var app = builder.Build();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  app.UseHsts();
}
else
{
  app.UseDeveloperExceptionPage();
  app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// spodnje pred UseRouting
app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agri-analytica API v1");
});

app.UseRouting();

// IMPORTANT: Ensure UseAuthentication is called before UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
  endpoints.MapControllers(); // Maps routes to controllers
  // For MVC or Razor Pages, you might also have endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
