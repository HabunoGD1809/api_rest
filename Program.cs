using Newtonsoft.Json;
//40214727543
//2022-09-01, Franklin Joel Valdez De Los Santos, Sabado 18 de Junio de 2022

try{
         //long cedula = conversor.leerNumero("Ingrese una c\u00e9dula: ");
         Console.Write("Ingrese una c\u00e9dula: ");
         string cedula = Console.ReadLine() ?? "Error";

         //create Json and deserialize it
         var client = new HttpClient();
         var jsonResponse = await client.GetStringAsync($"https://api.adamix.net/apec/cedula/{cedula}");
         Console.WriteLine($"{Environment.NewLine}Un momento por favor...");
         
         var persona = JsonConvert.DeserializeObject<persona>(jsonResponse)?? new persona();

         //console
         if(persona.ok){

                  Console.WriteLine(persona.foto);
                  Console.WriteLine(persona.Nombres);
                  Console.WriteLine($"{persona.Apellido1} {persona.Apellido2}");
                  //Console.WriteLine(persona.fecha());
                  Console.WriteLine($"{persona.edad()} a\u00f1os");

                  //read html
                  string html = System.IO.File.ReadAllText("read.html");

                  //web browser
                  html = html.Replace("{foto}", persona.foto);
                  html = html.Replace("{nombre}", persona.Nombres);
                  html = html.Replace("{apellido}", $"{persona.Apellido1} {persona.Apellido2}");
                  html = html.Replace("{fechaNacimiento}", persona.fecha().ToString());
                  html = html.Replace("{edad}", persona.edad().ToString());

                  //write html
                  System.IO.File.WriteAllText("Layout.html", html);
                  var process = new System.Diagnostics.ProcessStartInfo();
                  process.UseShellExecute = true;
                  process.FileName = "Layout.html";
                  System.Diagnostics.Process.Start(process);
         }
         else{
          Console.WriteLine(@"
          
  Persona no encontrada
        _..._
      .'     '.      _
     /    .----\   _/ \
   .-|   /:.   |  |   |
   |  \  |:.   /.-'-./
   | .-'-;:__.'    =/
   .'=  *=|Error_.='
  /   _.  |    ;
 ;-.-'|    \   |
/   | \    _\  _\
\__/'._;.  ==' ==\
         \    \   |
         /    /   /
         /-._/-._/
         \   `\  \
          `-._/._/       
          ");
         }
}
catch(Exception e){
    Console.WriteLine($@"
Ha ocurrido un error 

  Detalles del error: {e.Message}");
}
