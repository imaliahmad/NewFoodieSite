using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Commands;
using FoodieSite.CQRS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodieSite.CQRS.Queries.interfaces;
using FoodieSite.CQRS.Queries;
using FoodieSite.CQRS.Repositories.interfaces;
using FoodieSite.CQRS.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Service cors
builder.Services.AddCors(p => p.AddPolicy("FoodieSiteCors", builder =>
{
	builder.SetIsOriginAllowed(origin => true)
		   .AllowAnyMethod()
		   .AllowAnyHeader()
		   .AllowCredentials();
}));
// Session
builder.Services.AddSession(options => {
	options.IdleTimeout = TimeSpan.FromMinutes(1440);
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
	options.SuppressModelStateInvalidFilter = true;
});

//Connection String
builder.Services.AddDbContext<EFCoreDbContext>
	(options => options.UseSqlServer(builder.Configuration.
									 GetConnectionString("DbConfig")));


#region Register Commands
builder.Services.AddTransient<IRestaurantMasterCommands, RestaurantMasterCommands>();
builder.Services.AddTransient<IStoreMasterCommands, StoreMasterCommands>();
#endregion

#region Register Queries
builder.Services.AddTransient<IRestaurantMasterQueries, RestaurantMasterQueries>();
builder.Services.AddTransient<IStoreMasterQueries, StoreMasterQueries>();
#endregion
#region Register Repositories
builder.Services.AddTransient<IRestaurantMasterCommandRepository, RestaurantMasterCommandRepository>();
builder.Services.AddTransient<IRestaurantMasterQueryRepository, RestaurantMasterQueryRepository>();
builder.Services.AddTransient<IStoreMasterCommandRepository, StoreMasterCommandRepository>();
builder.Services.AddTransient<IStoreMasterQueryRepository, StoreMasterQueryRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error"); //404 (Not Found)
	app.UseStatusCodePagesWithReExecute("/Error/{0}"); //500 (Internal Server Error)
}
app.UseCors("FoodieSiteCors");


app.UseStaticFiles();
app.UseSession();
app.UseRouting();

//app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});
app.Run();