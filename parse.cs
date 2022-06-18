class conversor{
         public static long leerNumero(string mensaje){
             long numero;
             Console.Write(mensaje);
             while(!long.TryParse(Console.ReadLine(), out numero)){
                 Console.Write($"Ingrese una c\u00e9dula valida: ");
             }
             return numero;
         }
}