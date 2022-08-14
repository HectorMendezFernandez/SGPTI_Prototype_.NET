using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//se agrega este servicio para utilizar autenticacion de cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        //indicamos el path de la pagina de acceso
        option.LoginPath = "/Acceso/Index";
        //le decimos que expire en 20 minutos
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        //denegamos el acceso a una vista cuando no se esta autorizado por algun rol etc
        option.AccessDeniedPath = "/Home/AccessDenied";
    }
 );

//se agregan servicios par ausar la sesion
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

//usamos estos dos middlewares para inicios de sesion con cookies
app.UseAuthentication();
app.UseAuthorization();
//usamos este middleware para usar el session (importante que se ubique despues del UseRouting)
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Index}/{id?}");

app.Run();
