using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacion<T>(this HttpContext httpContext,
            IQueryable<T> queryable, int cantidadRegistrosPorPagina)
        {
            double cantidad = await queryable.CountAsync(); //se hace el conteo
            double cantidadPaginas = Math.Ceiling(cantidad / cantidadRegistrosPorPagina); 
            httpContext.Response.Headers.Add("cantidadPaginas",cantidadPaginas.ToString());
        }
    }
}
