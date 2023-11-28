using MongoDB.Driver;
public class BaseDatos{
    private string conexion = "mongodb+srv://sindyluledezmahernandezgen22:1234@cluster0.l50uofe.mongodb.net/?retryWrites=true&w=majority";
    private string baseDatos = "proyecto";
    public IMongoCollection<T>? ObtenerColeccion<T>(string coleccion){
        MongoClient client = new MongoClient(this.conexion);
        IMongoCollection<T>? collection = client.GetDatabase(this.baseDatos).GetCollection<T>(coleccion);
         
         return collection;
         
    }
}