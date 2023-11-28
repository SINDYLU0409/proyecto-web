using MongoDB.Bson;
using MongoDB.Driver;
public class Registrarse{
    public ObjectId Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Email { get; set; } = "";
    public string Contraseña { get; set;} = "";
    
}