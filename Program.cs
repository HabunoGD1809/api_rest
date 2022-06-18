using Newtonsoft.Json;

//2022-09-01, Franklin Joel Valdez De Los Santos, Sabado 18 de Junio de 2022

try{
         long cedula = conversor.leerNumero("Ingrese una c\u00e9dula: ");

         //create Json and deserialize it
         var client = new HttpClient();
         var jsonResponse = await client.GetStringAsync($"https://api.adamix.net/apec/cedula/{cedula}");
         Console.WriteLine($"Un momento por favor...{Environment.NewLine}");
         var persona = JsonConvert.DeserializeObject<persona>(jsonResponse);

         //console
         Console.WriteLine(persona.foto);
         Console.WriteLine(persona.Nombres);
         Console.WriteLine($"{persona.Apellido1} {persona.Apellido2}");
         Console.WriteLine(persona.FechaNacimiento);
         Console.WriteLine($"{persona.edad()} a\u00f1os");

         //read html
         string html = System.IO.File.ReadAllText("layout.html");

         //web browser
         html = html.Replace("{foto}", persona.foto);
         html = html.Replace("{nombre}", persona.Nombres);
         html = html.Replace("{apellido}", $"{persona.Apellido1} {persona.Apellido2}");
         html = html.Replace("{fechaNacimiento}", persona.FechaNacimiento);
         html = html.Replace("{edad}", persona.edad().ToString());

         System.IO.File.WriteAllText("layout.html", html);

         //write html
         var process = new System.Diagnostics.ProcessStartInfo();
         process.UseShellExecute = true;
         process.FileName = "layout.html";
         System.Diagnostics.Process.Start(process);

}
catch(Exception e){
    Console.WriteLine($"Ha ocurrido un error IMAGEN: {e.Message}");
}
