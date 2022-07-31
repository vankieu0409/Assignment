using Iot.Assignment.Infrastructure.Extentions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// import ServiceCollectionExtensions at infrastructure ( bao gồm tiêm sự phụ thuộc. cài JWt. và 1 số cái khác)
builder.Services.AddAuthorization(options => // cài Authorization
{
    //options.AddPolicy(TimelinePolicies.Create, policy => policy.RequireAssertion(context => context.User.HasClaim(c => c.Value == TimelinePolicies.FullAccess || c.Value == TimelinePolicies.Create)));
    //options.AddPolicy(TimelinePolicies.View, policy => policy.RequireAssertion(context => context.User.HasClaim(c => c.Value == TimelinePolicies.FullAccess || c.Value == TimelinePolicies.View)));
    //options.AddPolicy(TimelinePolicies.Update, policy => policy.RequireAssertion(context => context.User.HasClaim(c => c.Value == TimelinePolicies.FullAccess || c.Value == TimelinePolicies.Update)));
    //options.AddPolicy(TimelinePolicies.Delete, policy => policy.RequireAssertion(context => context.User.HasClaim(c => c.Value == TimelinePolicies.FullAccess || c.Value == TimelinePolicies.Delete)));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
