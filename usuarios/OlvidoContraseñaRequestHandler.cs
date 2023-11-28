using MongoDB.Driver;
public class OlvidoContraseñaRequestHandler{
     public static IResult Recuperar(Registrarse Datos){
        if (string.IsNullOrEmpty(Datos.Email)){
            return Results.BadRequest("El correo es requerido");
        }
        BaseDatos bd = new BaseDatos();
        var coleccion = bd.ObtenerColeccion<Registrarse>("usuarios");
        if(coleccion==null){
            throw new Exception("No existe la coleccion Usuarios");
        }
        FilterDefinitionBuilder<Registrarse> filterBuilder = new FilterDefinitionBuilder<Registrarse>();
        var filter = filterBuilder.Eq(x => x.Email, Datos.Email);

        Registrarse? usuarioExistente = coleccion.Find(filter).FirstOrDefault();
        if (usuarioExistente == null){
            return Results.BadRequest("No existe un usuario con el correo proporcionado");
        }
        System.Net.Mail.MailMessage message=new System.Net.Mail.MailMessage();
        message.Subject="Recuperacion de contraseña";
        message.From= new System.Net.Mail.MailAddress("sanmartinluna0@gmail.com");
        message.Body="Tu contraseña es: "+usuarioExistente.Contraseña;
        message.To.Add(usuarioExistente.Email);
        System.Net.Mail.SmtpClient smtp= new System.Net.Mail.SmtpClient();
        smtp.Credentials=new System.Net.NetworkCredential("sanmartinluna0@gmail.com","mvaj keka yxjm pxuu");
        smtp.Port=25;
        smtp.Host="smtp.gmail.com";
        smtp.EnableSsl=true;

        smtp.Send(message);

        return Results.Ok();
    }
}