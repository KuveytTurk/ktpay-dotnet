using KTPay.Helpers;
using KTPay.Helpers.Interfaces;
using KTPay.Services;
using KTPay.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddScoped(typeof(IKTPayClient), typeof(KTPayClient));
builder.Services.AddScoped(typeof(IKTPayService), typeof(KTPayService));

var app = builder.Build();
app.UseDeveloperExceptionPage();
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=KTPay}/{action=Index}/{id?}"
);
app.Run();