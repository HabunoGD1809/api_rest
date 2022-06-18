public class persona
{
         public string Cedula { get; set; } = "";
         public string Nombres { get; set; } = "";
         public string Apellido1 { get; set; } = "";
         public string Apellido2 { get; set; } = "";
         public string FechaNacimiento { get; set; } = "";
         public string LugarNacimiento { get; set; } = "";
         public string IdSexo { get; set; } = "";
         public string IdEstadoCivil { get; set; } = "";
         public string IDEstatus { get; set; } = "";
         public object EstatusCedulaAzul { get; set; } = "";
         public object CedulaAnterior { get; set; } = "";
         public bool ok { get; set; } = false;
         public string foto { get; set; } = "";
         public int edad(){
                  var FechaNacimiento = DateTime.Parse(this.FechaNacimiento);
                  var FechaActual = DateTime.Now;

                  int edad = FechaActual.Year - FechaNacimiento.Year;
                  return edad;
         }
}

