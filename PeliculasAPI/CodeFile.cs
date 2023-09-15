// Gia para crear una API: 

// Se crea la entidad que se va a usar, en este caso empezamos por genero.cs, luego se instalan los paquetes de sqlserver y de tools
//para poder operar con la base de datos. Luego en appsettings o appsettings.Development.json se escribe el connection string asi

//  "ConnectionStrings": {
//"DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PeliculasAPI;Integrated Security = True"
// }, esto es para tener una conexion con la base de datos 

//Se agrega el ApplicationDbContext.cs 

//Se agrega al pogram.cs el codigo para cargar el ApplicationDbContext

//En controllers, se añade el controlador donde se especificara lo siguiente 

//using Microsoft.AspNetCore.Mvc;
//using PeliculasAPI;

//[ApiController]
//[Route("api/generos")]
//public class GenerosController : ControllerBase
//{
//  private readonly ApplicationDbContext context;

// public GenerosController(ApplicationDbContext context)
//{
//  this.context = context;
//}

//Luego se crean los mapeos, para esto se crea una carpeta con los DTOs, luego una clase llamada GeneroDTO con las mismas entradas 
//que hay en genero.cs, luego creamos una clase para los mapeos, en este caso, AutoMapperProfiles.cs y se hacen los mapeos desde 
//ahi. Finalmente, se trabaja con program.cs para inicializar los mapeos con este comando 

//builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


//Cuando se añada una nueva tabla, se debe añadir su entidad, luego a applicationDbContext y la migracion en la consola 