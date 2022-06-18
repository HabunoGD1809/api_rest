using Newtonsoft.Json;

//debes poner un comentario con tu matricula, nombre completo y fecha en la cual estas haciendo ese vídeo
//2022-09-01, Franklin Joel Valdez De Los Santos, Sabado 18 de Junio de 2022

try{
         long cedula = conversor.leerNumero("Ingrese una c\u00e9dula: ");

         var client = new HttpClient();
         var jsonResponse = await client.GetStringAsync($"https://api.adamix.net/apec/cedula/{cedula}");

         Console.WriteLine($"Un momento por favor...{Environment.NewLine}");

         var persona = JsonConvert.DeserializeObject<persona>(jsonResponse);

         Console.WriteLine($"{persona.Nombres} {persona.Apellido1} {persona.Apellido2}");

} catch(Exception e){
    Console.WriteLine($"Hubo un error: {e.Message}");
}
