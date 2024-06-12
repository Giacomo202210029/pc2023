// Importamos el espacio de nombres Microsoft.AspNetCore.Mvc.ModelBinding
using Microsoft.AspNetCore.Mvc.ModelBinding;

// Declaramos un espacio de nombres para organizar nuestro código
namespace catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

// Creamos una clase estática para nuestras extensiones de ModelState
public static  class ModelStateExtensions
{
    // Creamos un método de extensión para obtener los mensajes de error de un ModelStateDictionary
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        // Usamos LINQ para seleccionar todos los errores en el ModelStateDictionary
        // Luego seleccionamos solo el mensaje de error de cada error
        // Finalmente, convertimos el resultado en una lista y lo devolvemos
        return dictionary
            .SelectMany(x => x.Value.Errors) // Seleccionamos todos los errores en el ModelStateDictionary
            .Select(x => x.ErrorMessage) // Seleccionamos solo el mensaje de error de cada error
            .ToList(); // Convertimos el resultado en una lista
    }
}