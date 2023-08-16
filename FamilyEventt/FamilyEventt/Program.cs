using FamilyEventt.Controllers;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FamilyEventt.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
/*using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;*/
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<FamilyEventContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection1"))
    );
/*builder.Services.AddDbContext<FamilyEventContext>(options =>
{
    if (builder.Environment.EnvironmentName == "Development")
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection1"));
    }
    else
    {
        options.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection1"));
    }
});*/
//Out of line

//Khai b�o 
builder.Services.AddScoped<IDrink, DrinkService>();
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IGameServices, GameSvService>();
builder.Services.AddScoped<IShowServices, ShowSvService>();
builder.Services.AddScoped<IFoodType, FoodTypeService>();
builder.Services.AddScoped<IEventBooker, EventBookerService>();
builder.Services.AddScoped<IFood, FoodService>();
builder.Services.AddScoped<IAccount, AccountService>();
builder.Services.AddScoped<IDecoration, DecorationService>();
builder.Services.AddScoped<IDecorationProduct, DecorationProductService>();
builder.Services.AddScoped<IMenuProduct, MenuProductService>();
builder.Services.AddScoped<IEvent, EventService>();
builder.Services.AddScoped<IEventType, EventTypeService>();
builder.Services.AddScoped<IChat, ChatMessageService>();
builder.Services.AddScoped<IParticipant, ParticipantService>();
builder.Services.AddScoped<IScript, ScriptService>();
builder.Services.AddScoped<IFeedback, FeedbackService>();
builder.Services.AddScoped<IMenu, MenuService>();
builder.Services.AddScoped<IBooking, BookingService>();
builder.Services.AddScoped<IFamily, FamilyService>();
builder.Services.AddScoped<IRoomLocation, RoomLocationService>();
builder.Services.AddScoped<IEntertainment,EntertainmentServices>();
builder.Services.AddScoped<IEntertainmentProduct,EntertainmentProductServices>();
builder.Services.AddScoped<INotification, NotificationService>();
builder.Services.AddScoped<IStatistical,StatisticalService>();
builder.Services.AddScoped<IPaymentStatistical, PaymentService>();
builder.Services.AddScoped<IVoucher, VoucherService>();
builder.Services.AddScoped<ITwillioService, TwillioService>();
builder.Services.AddScoped<IFireBase, FirebaseService>();
builder.Services.AddScoped<IAdminConfig, AdminConfigService>();



builder.Services.AddScoped(typeof(FamilyEventContext));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Options =>
{
    Options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
    Options.SaveToken = true;
    Options.RequireHttpsMetadata = false;
});

builder.Services.AddAuthorization();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("FamilyEvent", new OpenApiInfo() {Title="Family Event", Version="v1" });
    //setup comment in swagger UI
    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentFileFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

    option.IncludeXmlComments(xmlCommentFileFullPath);
});
var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FamilyEventApi v1"));
//}

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/FamilyEvent/swagger.json", "FamilyEventApi v1"));

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


