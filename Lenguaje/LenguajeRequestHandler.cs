using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
public static class LenguajeRequestHandler{
public static IResult ListarRegistros(string idCategoria){
    var filterBuilder = new FilterDefinitionBuilder<LenguajeDbMap>();
    var filter = filterBuilder.Eq(x => x.IdCategoria, idCategoria);
    BaseDatos bd = new BaseDatos();
    var coleccion = bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
    var lista = coleccion.Find(filter).ToList();
    return Results.Ok(lista.Select(x => new {
        Id = x.Id.ToString(),
        idCategoria = x.IdCategoria,
        Titulo = x.Titulo,
        Descripcion = x.Descripcion,
        EsVideo = x.EsVideo,
        Url = x.Url
           }).ToList());
}
public static IResult CrearRegistro (LenguajeDTO dTO){
         if(string.IsNullOrWhiteSpace(dTO.Descripcion)){
            return Results.BadRequest("la descripcion es requerida");
        }
         if(string.IsNullOrWhiteSpace(dTO.Titulo)){
            return Results.BadRequest("el titulo es requerido");
        }
         if(string.IsNullOrWhiteSpace(dTO.Url)){
            return Results.BadRequest("el url es requerido");
        }
        if (!ObjectId.TryParse(dTO.IdCategoria, out ObjectId IdCategoria)){
            return Results.BadRequest($"El Id de la categoria ({dTO.IdCategoria}) no es valido");
            }
            BaseDatos bd = new BaseDatos();
            var filterBuilderCategorias = new FilterDefinitionBuilder<CategoriaDbMap>();
            var filterCategoria = filterBuilderCategorias.Eq(x => x.Id, IdCategoria);
            var coleccionCategoria = bd.ObtenerColeccion<CategoriaDbMap>("Categorias");
            var categoria = coleccionCategoria.Find(filterCategoria).FirstOrDefault();

            if(categoria == null){
                return Results.NotFound($"no existe una categoria con ID = '{dTO.IdCategoria}'");
            }
            LenguajeDbMap registro=new LenguajeDbMap();
            registro.Titulo=dTO.Titulo;
            registro.EsVideo = dTO.EsVideo;
            registro.Descripcion= dTO.Descripcion;
            registro.Url=dTO.Url;
            registro.IdCategoria=dTO.IdCategoria;
            var coleccionLenguaje =bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
            coleccionLenguaje.InsertOne(registro);
            return Results.Ok(registro.Id.ToString());
         
}
public static IResult Eliminar(string id){
    if(!ObjectId.TryParse(id, out ObjectId idLenguaje)){
        return Results.BadRequest($"El Id proporcionado ({id}) no es válido");
    }
    BaseDatos bd = new BaseDatos();
    var filterBuilder = new FilterDefinitionBuilder<LenguajeDbMap>();
    var filter = filterBuilder.Eq(x => x.Id, idLenguaje);
    var coleccion= bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
    coleccion!.DeleteOne(filter);
    return Results.NoContent();
}
    public static IResult Buscar (string texto) {
        var queryExpr = new BsonRegularExpression(new Regex(texto, RegexOptions.IgnoreCase));
        var filterBuilder = new FilterDefinitionBuilder<LenguajeDbMap>();
        var filter = filterBuilder.Regex("Titulo", queryExpr) |
        filterBuilder.Regex("Descripcion", queryExpr);

        BaseDatos bd = new BaseDatos();
        var coleccion = bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
        var lista = coleccion.Find(filter).ToList();

        return Results.Ok(lista.Select(x => new{
            Id = x.Id.ToString(),
            IdCategoria = x.IdCategoria,
            Titulo = x.Titulo,
            Descripcion = x.Descripcion,
            EsVideo = x.EsVideo,
            Url = x.Url
        }).ToList());

    }
}

