using Microsoft.EntityFrameworkCore;

namespace catchupcomplete.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    // Creamos un método de extensión para aplicar la convención de nomenclatura snake_case a todas las entidades y propiedades
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        // Iteramos sobre todas las entidades en el modelo
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Obtenemos el nombre de la tabla de la entidad
            var tablename = entity.GetTableName();
            // Si el nombre de la tabla no está vacío
            if (!string.IsNullOrEmpty(tablename ))
                // Establecemos el nombre de la tabla a su versión en snake_case
                entity.SetTableName(tablename.ToSnakeCase());

            // Iteramos sobre todas las propiedades de la entidad
            foreach(var property in entity.GetProperties())
            {
                // Obtenemos el nombre de la columna de la propiedad
                var columnName = property.GetColumnName();
                // Si el nombre de la columna no está vacío
                if (!string.IsNullOrEmpty(columnName))
                    // Establecemos el nombre de la columna a su versión en snake_case
                    property.SetColumnName(columnName.ToSnakeCase());
            }

            // Iteramos sobre todas las claves de la entidad
            foreach (var key in entity.GetKeys())
            {
                // Obtenemos el nombre de la clave
                var keyName = key.GetName();
                // Si el nombre de la clave no está vacío
                if (!string.IsNullOrEmpty(keyName))
                    // Establecemos el nombre de la clave a su versión en snake_case
                    key.SetName(keyName.ToSnakeCase());
            }

            // Iteramos sobre todas las claves foráneas de la entidad
            foreach (var fkey in entity.GetForeignKeys())
            {
                // Obtenemos el nombre de la restricción de la clave foránea
                var foreignkey = fkey.GetConstraintName();
                // Si el nombre de la restricción no está vacío
                if(!string.IsNullOrEmpty(foreignkey))
                    // Establecemos el nombre de la restricción a su versión en snake_case
                    fkey.SetConstraintName(foreignkey.ToSnakeCase());
            }

            // Iteramos sobre todos los índices de la entidad
            foreach (var index in entity.GetIndexes())
            {
                // Obtenemos el nombre del índice
                var indexName = index.GetDatabaseName();
                // Si el nombre del índice no está vacío
                if (!string.IsNullOrEmpty(indexName))
                    // Establecemos el nombre del índice a su versión en snake_case
                    index.SetDatabaseName(indexName.ToSnakeCase());
            }
        }
    }
}