using Library.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(setupAction =>
{
    setupAction.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters()
    .AddNewtonsoftJson()
   .ConfigureApiBehaviorOptions(setupAction =>
   {
       setupAction.InvalidModelStateResponseFactory = context =>
       {
           // create a problem details object
           ProblemDetailsFactory problemDetailsObject = context.HttpContext.RequestServices
            .GetRequiredService<ProblemDetailsFactory>();

           var problemDetails = problemDetailsObject.CreateValidationProblemDetails(context.HttpContext, context.ModelState);
           problemDetails.Detail = "See the errors field for details.";
           problemDetails.Instance = context.HttpContext.Request.Path;

           // find out which status code to use.
           var actionExecutingContext = context as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

           // if there are model state errors & all arguments were correctly fund/parsed we're dealing with validation errors.
           if ((context.ModelState.ErrorCount > 0) && (
            actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count
           ))
           {
               problemDetails.Type = "https://albertraza.com/ejemplo";
               problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
               problemDetails.Title = "One or more validation errors occurred.";

               return new UnprocessableEntityObjectResult(problemDetails)
               {
                   ContentTypes = { "application/problem+json" }
               };
           }

           // if one of the arguments wasn't correctly found / couldn't be parsed.
           // We're dealing with null/unparseable input.
           problemDetails.Status = StatusCodes.Status400BadRequest;
           problemDetails.Title = "One or more errors on input occurred.";
           return new BadRequestObjectResult(problemDetails)
           {
               ContentTypes = { "application/problem+json" }
           };
       };
   });

builder.Services.ConfigureServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
