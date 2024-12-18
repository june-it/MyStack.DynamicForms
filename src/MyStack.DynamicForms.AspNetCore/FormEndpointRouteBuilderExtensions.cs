using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace MyStack.DynamicForms.AspNetCore
{
    public static class FormEndpointRouteBuilderExtensions
    {
        public const string RouteName = "Form";
        public static IEndpointRouteBuilder AddCreateFormEndpoint<T>(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("Form", async (CreateOrUpdateFormModel model, IFormStore formStore, ILogger<IEndpointRouteBuilder> logger) =>
            {

                try
                {
                    var form = BuildFormFromModel(model);
                    await formStore.InsertAsync(form);

                    return TypedResults.Ok(new
                    {
                        success = true,
                        message = ""
                    });
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                    return TypedResults.Ok(new
                    {
                        success = false,
                        message = ex.Message
                    });
                }
            })
            .AllowAnonymous()
            .WithName(RouteName)
            .DisableAntiforgery();

            return builder;
        }
        public static IEndpointRouteBuilder AddUpdateFormEndpoint<T>(this IEndpointRouteBuilder builder)
        {
            builder.MapPut("Form", async (CreateOrUpdateFormModel model, IFormStore formStore, ILogger<IEndpointRouteBuilder> logger) =>
            {
                try
                {
                    var form = BuildFormFromModel(model);
                    await formStore.UpdateAsync(form);

                    return TypedResults.Ok(new
                    {
                        success = true,
                        message = ""
                    });
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                    return TypedResults.Ok(new
                    {
                        success = false,
                        message = ex.Message
                    });
                }

            })
            .AllowAnonymous()
            .WithName(RouteName)
            .DisableAntiforgery();

            return builder;
        }
        private static Form BuildFormFromModel(CreateOrUpdateFormModel model)
        {
            var form = new FormBuilder().New(model.Name, model.DisplayName);
            if (model.Fields != null)
            {
                foreach (var field in model.Fields)
                {
                    switch (field.FieldType)
                    {
                        case Fields.FieldType.Boolean:
                            break;
                        case Fields.FieldType.Date:
                            break;
                        case Fields.FieldType.DateTime:
                            break;
                        case Fields.FieldType.Html:
                            break;
                        case Fields.FieldType.Link:
                            break;
                        case Fields.FieldType.Markdown:
                            break;
                        case Fields.FieldType.Image:
                            break;
                        case Fields.FieldType.MultiText:
                            break;
                        case Fields.FieldType.Numeric:
                            break;
                        case Fields.FieldType.Text:
                            break;
                        case Fields.FieldType.Time:
                            break;
                        case Fields.FieldType.File:
                            break;
                        default:
                            break;
                    }
                }
            }
            return form.Build();
        }
    }
}
