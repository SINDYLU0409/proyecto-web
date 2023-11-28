using MongoDB.Driver;
public class IniciarSesionRequestHandler{
      public static IResult Sesion (Registrarse datos){
        string errores = "";
         if (string.IsNullOrWhiteSpace (datos.Email)){
       errores +="El correo es requerido";
      }
        if (string.IsNullOrWhiteSpace(datos.Contraseña)){
       errores +="la contraseña es requerida";
      }
      BaseDatos bd = new BaseDatos();
      var coleccion =  bd.ObtenerColeccion<Registrarse>("usuarios");
      if(coleccion == null){
        throw new Exception("No existe la coleccion usuarios");

      }
      FilterDefinitionBuilder<Registrarse> filterBuider = new FilterDefinitionBuilder<Registrarse>();
      var filter = filterBuider.Eq(x=> x.Email, datos.Email);

      Registrarse? usuarioExistente = coleccion.Find(filter).FirstOrDefault();
      if (usuarioExistente == null){
        return Results.BadRequest($"No se ha encontrado el correo {datos.Email}");

      }
      if (usuarioExistente.Contraseña != datos.Contraseña){
        return Results.BadRequest($"usuario o contraseña incorrecta");
      }
      return Results.Ok();
      

      }

}
