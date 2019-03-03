using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace HelloValidateConfiguration
{
    public static class ConfigurationValidator
    {
        public static void Validate(this IConfiguration configuration)
        {
            var validationErrors = new List<KeyValuePair<string, Exception>>();

            foreach (var propertyInfo in typeof(IConfiguration).GetProperties())
            {
                var validatorAttributes = propertyInfo
                    .GetCustomAttributes(typeof(ConfigurationValidatorAttribute))
                    .Cast<ConfigurationValidatorAttribute>();

                var value = propertyInfo.GetValue(configuration);
                var propertyName = propertyInfo.Name;

                foreach (var customAttributeData in validatorAttributes)
                {
                    try
                    {
                        var validatorInstance = customAttributeData.ValidatorInstance;
                        validatorInstance.Validate(value);
                    }
                    catch (Exception e)
                    {
                        validationErrors.Add(new KeyValuePair<string, Exception>(propertyName, e));
                    }
                }
            }

            if (validationErrors.Any())
            {
                var exception = new Exception("Configuration validation failed");
                exception.Data["ValidationErrors"] = validationErrors;

                throw exception;
            }
        }
    }
}