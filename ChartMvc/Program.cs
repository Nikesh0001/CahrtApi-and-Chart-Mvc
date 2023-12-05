var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string apiUrl = "https://localhost:7229/api/Common";
builder.Services.AddSingleton(apiUrl);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Addcors for redirecting from the react
app.UseCors(options =>
{
    options.WithOrigins("https://localhost:3000")//react url
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.UseAuthorization();




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Chart}/{action=Home}/{id?}");

app.Run();