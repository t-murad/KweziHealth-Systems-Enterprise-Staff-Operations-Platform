using KweziHealth_Systems_Enterprise_Staff_Operations_Platform.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add Application services
builder.Services.AddSingleton<StaffService>();

//Configure Session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

//Enable Session
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

//Configure MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
