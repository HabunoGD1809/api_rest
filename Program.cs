using Newtonsoft.Json;

//2022-09-01, Franklin Joel Valdez De Los Santos, Sabado 18 de Junio de 2022

try{
         long cedula = conversor.leerNumero("Ingrese una c\u00e9dula: ");

         //create Json and deserialize it
         var client = new HttpClient();
         var jsonResponse = await client.GetStringAsync($"https://api.adamix.net/apec/cedula/{cedula}");
         Console.WriteLine($"Un momento por favor...{Environment.NewLine}");
         persona persona = JsonConvert.DeserializeObject<persona>(jsonResponse)?? new persona();

         //console
         Console.WriteLine(persona.foto);
         Console.WriteLine(persona.Nombres);
         Console.WriteLine($"{persona.Apellido1} {persona.Apellido2}");
         Console.WriteLine(persona.FechaNacimiento);
         Console.WriteLine($"{persona.edad()} a\u00f1os");

         //read html
         string html = System.IO.File.ReadAllText("Layout.html");

         //web browser
         html = html.Replace("{foto}", persona.foto);
         html = html.Replace("{nombre}", persona.Nombres);
         html = html.Replace("{apellido}", $"{persona.Apellido1} {persona.Apellido2}");
         html = html.Replace("{fechaNacimiento}", persona.FechaNacimiento);
         html = html.Replace("{edad}", persona.edad().ToString());

         //write html
         System.IO.File.WriteAllText("Layout.html", html);
         var process = new System.Diagnostics.ProcessStartInfo();
         process.UseShellExecute = true;
         process.FileName = "layout.html";
         System.Diagnostics.Process.Start(process);

}
catch(Exception e){
    Console.WriteLine($@"
    
Ha ocurrido un error 
        _..._
      .'     '.      _
     /    .----\   _/ \
   .-|   /:.   |  |   |
   |  \  |:.   /.-'-./
   | .-'-;:__.'    =/
   .'=  *=|Joel _.='
  /   _.  |    ;
 ;-.-'|    \   |
/   | \    _\  _\
\__/'._;.  ==' ==\
         \    \   |
         /    /   /
         /-._/-._/
         \   `\  \
          `-._/._/
         
         {e.Message}");
}
