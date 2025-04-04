﻿using System;
using System.Collections.Generic;

class ProgramaMenstrual
{
    static void Main()
    {
        Console.WriteLine("Bienvenida a tu Aplicación de Control Menstrual");

        Console.Write("Por favor, ingresa tu nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingresa la fecha de inicio de tu último ciclo menstrual (formato DD/MM/YYYY): ");
        DateTime fechaInicioCiclo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.Write("Ingresa la duración de tu ciclo menstrual (en días): ");
        int duracionCiclo = int.Parse(Console.ReadLine());

        Console.Write("Ingresa la duración de tu periodo (en días): ");
        int duracionPeriodo = int.Parse(Console.ReadLine());

        DateTime siguientePeriodo = fechaInicioCiclo.AddDays(duracionCiclo);
        DateTime fechaOvulacionInicio = siguientePeriodo.AddDays(-14);
        DateTime fechaOvulacionFin = fechaOvulacionInicio.AddDays(1);


        Console.Write("¿Estás planificando? (si/no): ");
        string planificando = Console.ReadLine().ToLower();


        string metodoAnticonceptivo = "";
        if (planificando == "si")
        {
            Console.Write("¿Qué método anticonceptivo estás utilizando? (Pastillas/Inyecciones): ");
            metodoAnticonceptivo = Console.ReadLine();
        }


        List<string> calendario = GenerarCalendario(siguientePeriodo, duracionCiclo, duracionPeriodo, fechaOvulacionInicio, fechaOvulacionFin);


        Console.WriteLine("\nCalendario de tu ciclo menstrual:");
        for (int i = 0; i < calendario.Count; i++)
        {
            Console.WriteLine(calendario[i]);
        }


        Console.Write("\n¿Deseas volver a utilizar el programa? (si/no): ");
        string respuesta = Console.ReadLine().ToLower();

        if (respuesta == "si")
        {
            Main();
        }
    }


    static List<string> GenerarCalendario(DateTime siguientePeriodo, int duracionCiclo, int duracionPeriodo, DateTime fechaOvulacionInicio, DateTime fechaOvulacionFin)
    {
        List<string> calendario = new List<string>();

        for (int i = 0; i < duracionCiclo; i++)
        {
            DateTime diaActual = siguientePeriodo.AddDays(i);
            string mensaje = "";

            if (i < duracionPeriodo)
            {
                mensaje = $"Día {diaActual.ToString("dd/MM/yyyy")} - Periodo Menstrual";
            }
            else if (diaActual >= fechaOvulacionInicio && diaActual <= fechaOvulacionFin)
            {
                mensaje = $"Día {diaActual.ToString("dd/MM/yyyy")} - Ovulación (Fértil)";
            }
            else
            {
                mensaje = $"Día {diaActual.ToString("dd/MM/yyyy")} - Fase del ciclo normal";
            }

            calendario.Add(mensaje);
        }

        return calendario;
    }
}