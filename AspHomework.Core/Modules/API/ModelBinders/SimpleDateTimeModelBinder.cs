using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspHomework.Core.Modules.API.ModelBinders
{
    public class SimpleDateTimeModelBinder: IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;
        
            // Try to fetch the value of the argument by name
            var valueProviderResult =
                bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName,
                valueProviderResult);

            var value = valueProviderResult.FirstValue;

            // Check if the argument value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            string[] dateParts = value.Split('.'); 
            if (dateParts.Length != 3)
            {
                // Non-integer arguments result in model state errors
                bindingContext.ModelState.TryAddModelError(
                    modelName,
                    "Specified date time must be in format 'dd.mm.yyyy'");
                return Task.CompletedTask;
            }

            int year = Convert.ToInt32(dateParts[2]);
            int month = Convert.ToInt32(dateParts[1]);
            int day = Convert.ToInt32(dateParts[0]);
            
            DateTime time = new DateTime(year, month, day);
                                                
            bindingContext.Result = ModelBindingResult.Success(time);
            return Task.CompletedTask;
        }
    }
}