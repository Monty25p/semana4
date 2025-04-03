using System;

class Presupuesto
{
    static void Main()
    {
        do
        {
            Console.WriteLine("Bienvenido al Control de Presupuesto");

            string usuario = PedirTexto("Ingrese su nombre: ");

            int opcionMoneda;
            string moneda = "C$";
            bool monedaValida = false;

            while (!monedaValida)
            {
                Console.Write("\n¿Desea calcular su presupuesto en (1) Córdobas o (2) Dólares? ");
                opcionMoneda = int.Parse(Console.ReadLine());
              
                    if (opcionMoneda == 1)
                    {
                        moneda = "C$";
                        monedaValida = true;
                    }
                    else if (opcionMoneda == 2)
                    {
                        moneda = "$";
                        monedaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Por favor ingrese 1 para Córdobas o 2 para Dólares.");
                    }
            }
            


            double ingreso = PedirNumero($"Ingrese su ingreso mensual ({moneda}): ");

            double[] listaDeudas = PedirLista(new string[] { "Casa", "Carro", "Tarjetas", "Otros" }, "deudas", moneda);
            double[] listaGastos = PedirLista(new string[] { "comida", "Colegiatura", "Transporte", "Entretenimiento", "Ropa", "Mascotas", "Accesorios", "Otros" }, "gastos", moneda);
            double[] listaServicios = PedirLista(new string[] { "Luz eléctrica", "Agua", "TV por cable", "Internet", "datos moviles", "Gas", "Otros" }, "servicios", moneda);

            double ahorro = PedirNumero($"Ingrese el monto de ahorro mensual ({moneda}): ");

            double totalDeudas = SumarLista(listaDeudas);
            double totalGastos = SumarLista(listaGastos) + SumarLista(listaServicios);

            VerificarPresupuesto(ingreso, totalDeudas, totalGastos, ahorro, moneda, usuario);

            Console.Write("\n¿Desea calcular otro presupuesto?");
        } while (Console.ReadLine().ToLower() == "si");

        Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
    }

    static string PedirTexto(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine();
    }

    static double PedirNumero(string mensaje)
    {
        double numero;
        while (true)
        {
            Console.Write(mensaje);
            numero = Convert.ToDouble(Console.ReadLine());
            if (numero >= 0)
            {
                return numero;
            }
            else
            {
                Console.WriteLine("El número debe ser mayor que 0.");
            }
        }
    }

    static double[] PedirLista(string[] nombres, string categoria, string moneda)
    {
        double[] valores = new double[nombres.Length];
        Console.WriteLine($"\nIngrese los montos para {categoria}:");
        for (int i = 0; i < nombres.Length; i++)
        {
            valores[i] = PedirNumero($"  {nombres[i]} ({moneda}): ");
        }
        return valores;
    }

    static double SumarLista(double[] valores)
    {
        double suma = 0;
        for (int i = 0; i < valores.Length; i++)
        {
            suma += valores[i];
        }
        return suma;
    }

    static void VerificarPresupuesto(double ingreso, double deudas, double gastos, double ahorro, string moneda, string usuario)
    {
        double ahorrop = (ahorro / ingreso) * 100;
        double deudap = (deudas / ingreso) * 100;
        double gastop = (gastos / ingreso) * 100;

        Console.WriteLine($"\nResumen del presupuesto mensual de {usuario}:");
        Console.WriteLine($"- Ahorro: {ahorrop:F2}% (Recomendado: 15%)");
        Console.WriteLine($"- Deudas: {deudap:F2}% (Recomendado: 35%)");
        Console.WriteLine($"- Gastos: {gastop:F2}% (Recomendado: 50%)");

        if (ahorrop >= 15 && deudap <= 35 && gastop <= 50)
        {
            Console.WriteLine("\n¡Todo en orden! Su presupuesto está bien distribuido.");
        }
        else
        {
            Console.WriteLine("\nRecomendaciones:");
            if (ahorrop < 15)
            {
                Console.WriteLine(" - Intente aumentar su ahorro para alcanzar al menos el 15%.");
                Console.WriteLine($"Si usted gana {ingreso} deberia ahorrar {ingreso * 0.15} y usted ahorra {ahorro}");
            }
               

            if (deudap > 35)
            {
                Console.WriteLine(" - Reduzca sus deudas para no superar el 35% de sus ingresos.");
                Console.WriteLine($"Si usted gana {ingreso} deberia ocupar en deudas un maximo de {ingreso * 0.35} y usted en deudas gasta {deudas} mensualmente");
            }
              
            if (gastop > 50)
            {
                Console.WriteLine(" - Controle sus gastos para que no superen el 50% de sus ingresos.");
                Console.WriteLine($"Si sus gastos  son de {ingreso} deberia gastar {ingreso * 0.5} como maximo, entre mas ahorre es mejor pero usted gasta mensualmente {gastos}");
            }
                
        }
    }
}
