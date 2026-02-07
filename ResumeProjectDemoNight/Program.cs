using ResumeProjectDemoNight.Context;

var builder = WebApplication.CreateBuilder(args);

// ✅ DB
builder.Services.AddDbContext<ResumeContext>();

// ✅ MVC
builder.Services.AddControllersWithViews();

// 🔥 EKLENECEK
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// ✅ ZORUNLU
app.UseStaticFiles();

app.UseRouting();

// 🔥 EKLENECEK
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
