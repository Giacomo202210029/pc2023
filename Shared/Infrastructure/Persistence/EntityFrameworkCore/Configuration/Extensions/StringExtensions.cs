// Declaramos un espacio de nombres para organizar nuestro código
namespace catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

// Creamos una clase estática para nuestras extensiones de cadena
public static class StringExtensions
{
    // Creamos un método de extensión para convertir una cadena a formato snake_case
    public static string ToSnakeCase(this string text)
    {
        // Usamos el método Convert para convertir la cadena y luego la convertimos a una matriz
        return new string(Convert(text.GetEnumerator()).ToArray());

        // Este es un método local que convierte la cadena a formato snake_case
        static IEnumerable<char> Convert(CharEnumerator e)
        {
            // Si la cadena está vacía, terminamos la ejecución
            if (!e.MoveNext()) yield break;

            // Convertimos el primer carácter a minúsculas y lo devolvemos
            yield return char.ToLower(e.Current);

            // Iteramos sobre el resto de la cadena
            while (e.MoveNext())
                // Si el carácter actual es una letra mayúscula
                if (char.IsUpper((e.Current)))
                {
                    // Agregamos un guion bajo antes de la letra mayúscula
                    yield return '_';
                    // Convertimos la letra mayúscula a minúscula y la devolvemos
                    yield return char.ToLower(e.Current);
                }
                // Si el carácter actual no es una letra mayúscula, simplemente lo devolvemos
                else yield return e.Current;
        }
    }
}