using System.Security.Cryptography.X509Certificates;
using MongoDB.Driver;
public class RegistrarseRequestHandler{
    public static IResult Registrar (Registrarse datos) {
        if (string.IsNullOrWhiteSpace (datos.Nombre)){
            return Results.BadRequest("El nombre es requerido");
 }
      if (string.IsNullOrWhiteSpace(datos.Email)){
        return Results.BadRequest("el correo es requerido");
      }   
     
         if (string.IsNullOrWhiteSpace(datos.Contraseña)){
        return Results.BadRequest("la contraseña es requerida");
      }
      BaseDatos bd =new BaseDatos();
      var coleccion = bd.ObtenerColeccion<Registrarse>("usuarios");
      if (coleccion == null){
        throw new Exception("No existe la coleccion usuarios");

      }
      FilterDefinitionBuilder<Registrarse> filterBuilder = new FilterDefinitionBuilder<Registrarse>();
      var filter = filterBuilder.Eq(x => x.Email, datos.Email);

      Registrarse? usuarioExistente = coleccion.Find(filter).FirstOrDefault();
      if (usuarioExistente != null){
        return Results.BadRequest($"Ya existe un usuario con el correo {datos.Email}");

      }

      coleccion.InsertOne(datos);

      return Results.Ok();

    }

}