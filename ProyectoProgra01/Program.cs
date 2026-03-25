// variables globales
int option = 0;
string nombre = "";
bool cumpleDuracion = false;
bool cumpleHora = false;
bool cumpleProduccion = true;
double totalEvaluados = 0;
double publicados = 0;
double rechazados = 0;
int revision = 0;
int impactoAlto = 0;
int impactoMedio = 0;
int impactoBajo = 0;
string predominante ="";
double porcentajeAprov = 0;
double porcentajeRech = 0;
double porcentajerev = 0;
int cantidad;

MenuPrincipal();
//inicio menu
void MenuPrincipal()
{
    Console.Clear();
    Console.WriteLine("  SIMULADOR DE DECISIONES PARA PLATAFORMA DE STREAMING\n ");
    do
    {
        Console.WriteLine("             Menú Principal\n   ");
        Console.WriteLine("     ¡Bienvenido al menú principal!\nEscoja una de las opciones disponibles.");
        Console.WriteLine("1.Evaluar Contenido\n2.Politicas\n3.Estadísticas\n4.Reiniciar Estadísticas\n5.Salir.");

        while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
        {
            Console.WriteLine("Error: Ingrese una opción válida (1, 2, 3, 4, 5):");
        }

        switch (option)
        {
            case 1:
                PedirDatos();
                break;
            case 2:
                Reglas();
                break;
            case 3:
                Estadisticas();
                break;
            case 4:
                Reinicio();
                break;
            case 5:
                Salida();
                break;
        }
    } while (option != 5);
}

void PedirDatos()
{
    Console.WriteLine("¿Cuántos contenidos desea evaluar?");
    while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 1)
    {
        Console.WriteLine("Error: Ingrese una cantidad válida:");
    }

    for (int i = 1; i <= cantidad; i++)
    {
        Console.Clear();
        Console.WriteLine("Tipo: 1.Película, 2.Serie, 3.Documental, 4.Evento en vivo:");
        int tipo;
        while (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 1 || tipo > 4)
        {
            Console.WriteLine("Error: Ingrese tipo válido (1, 2, 3, 4):");
        }
        switch (tipo)
        {
            case 1:
                EvaluarContenido("Película", 60, 180);
                break;
            case 2:
                EvaluarContenido("Serie", 20, 90);
                break;
            case 3:
                EvaluarContenido("Documental", 30, 120);
                break;
            case 4:
                EvaluarContenido("Evento en vivo", 30, 240);
                break;
        }
    }
}

void EvaluarContenido(string contenido, int min, int max)//case1
{
    Console.WriteLine($"Ingrese el nombre del {contenido}:");
    nombre = Console.ReadLine();

    Console.WriteLine($"¿Cuál es la duración del {contenido}? ({min}-{max} min):");
    int duracion;
    string entrada = Console.ReadLine();

    if (entrada == "")
    {
        Console.WriteLine("Error: Faltan los minutos.");
        duracion = 0;
        cumpleDuracion = false;
    }
    else if (!int.TryParse(entrada, out duracion))
    {
        Console.WriteLine("Error: No ingreso un número válido.");
        duracion = 0;
        cumpleDuracion = false;
    }
    else if (duracion < min || duracion > max)
    {
        cumpleDuracion = false;
    }
    else
    {
        cumpleDuracion = true;
    }

    Console.WriteLine("Ingrese la clasificación ( 1.- todo público, 2.- +13, 3.- +18 ):");
    int clasificaion;
    while (!int.TryParse(Console.ReadLine(), out clasificaion) || clasificaion < 1 || clasificaion > 3)
    {
        Console.WriteLine("Error: Ingrese clasificación válida:");
    }

    Console.WriteLine("Ingrese la hora programada (0-23):");
    int hora;
    while (!int.TryParse(Console.ReadLine(), out hora) || hora < 0 || hora > 23)
    {
        Console.WriteLine("Error: Ingrese una hora válida (0-23):");
    }

    if (clasificaion == 1)
    {
        cumpleHora = true;
    }
    else if (clasificaion == 2)
    {
        cumpleHora = (hora >= 6 && hora <= 22);
    }
    else if (clasificaion == 3)
    {
        cumpleHora = (hora >= 22 || hora <= 5);
    }

    Console.WriteLine("Nivel de Producción (1.Bajo, 2.Medio, 3.Alto):");
    int produccion;
    while (!int.TryParse(Console.ReadLine(), out produccion) || produccion < 1 || produccion > 3)
    {
        Console.WriteLine("Error: Ingrese un nivel válido.\n");
    }

    cumpleProduccion = !(produccion == 1 && clasificaion == 3);

    Console.WriteLine("\nResultado de la Evaluación ");
    totalEvaluados++;

    if (cumpleDuracion && cumpleHora && cumpleProduccion)
    {
        if (produccion == 3 || duracion > 120 || (hora >= 20 && hora <= 23))
        {
            impactoAlto++;
            revision++;
            Console.WriteLine("Estado: Enviar a revisión");
            Console.WriteLine("Razón: Cumple reglas pero tiene impacto Alto.\n");
        }
        else if (produccion == 2 || (duracion >= 60 && duracion <= 120))
        {
            impactoMedio++;
            publicados++;
            Console.WriteLine("Estado: Publicar");
            Console.WriteLine("Razón: Cumple reglas y tiene impacto Medio.\n");
        }
        else
        {
            impactoBajo++;
            publicados++;
            Console.WriteLine("Estado: Publicar");
            Console.WriteLine("Razón: El contenido tiene impacto Bajo");
        }
    }
    else
    {
        rechazados++;
        Console.WriteLine("Estado: Rechazar");

        if (!cumpleDuracion)
        {
            if (duracion < min)
            {
                Console.WriteLine($"Razón:Faltan minutos para el rango (Mínimo: {min}).");
            }
            else if (duracion > max)
            {
                Console.WriteLine($"Razón:Excede los minutos permitidos (Máximo: {max}).");
            }
            else
            {
                Console.WriteLine("Duración no válida.");
            }
        }
        if (!cumpleHora)
        {
            Console.WriteLine("Razón:El horario no es apto para la clasificación.");
        }
        if (!cumpleProduccion)
        {
            Console.WriteLine("Razón:Producción baja no permitida para la clasificación +18.\n");
        }
    }

    Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
    Console.ReadKey();
    Console.Clear();
}
void Reglas()//case 2
{
    Console.Clear();
    Console.WriteLine("  \nREGLAS OBLIGATORIAS\n ");
    Console.WriteLine("Reglas de clasificación y horario:\n");
    Console.WriteLine("• Todo público: cualquier hora\r\n• +13: entre 6:00 y 22:00 horas\r\n• +18: entre 22:00 y 5:00 horas\n");
    Console.WriteLine("Reglas de duración por tipo\n");
    Console.WriteLine("• Película: 60–180 minutos\r\n• Serie: 20 a 90 minutos\r\n• Documental: 30 a 120 minutos\r\n• Evento en vivo: 30 a 240 minutos\r\n");
    Console.WriteLine("Si la duración está fuera del rango permitido, el contenido no cumple la validación técnica.\n");
    Console.WriteLine("Reglas de producción\n");
    Console.WriteLine("• Producción baja solo válida para Todo público o +13\r\n• Producción media o alta válida para cualquier clasificación");
    Console.WriteLine("Clasificación de Impacto");
    Console.WriteLine("Impacto ALTO: Producción alta, duración > 120 min o horario entre 20:00 y 23:00.\n");
    Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
    Console.ReadKey();
    Console.Clear();
}


void Estadisticas()//case3
{
    Console.Clear();
    if (totalEvaluados > 0)
    {
        porcentajeAprov = (publicados / totalEvaluados) * 100;
        porcentajeRech = (rechazados / totalEvaluados) * 100;
        porcentajerev = (revision / totalEvaluados) * 100;
        Console.WriteLine($"Total de evaluados es: {totalEvaluados}");
        Console.WriteLine($"El total de Publicados es: {publicados}");
        Console.WriteLine($"El total de Rechazados es: {rechazados}");
        Console.WriteLine($"El total en Revision es: {revision}");
        Console.WriteLine($"El porcentaje de Aprovación: {porcentajeAprov:F2}%");
        Console.WriteLine($"El porcentaje de Rechazados: {porcentajeRech:F2}%");
        Console.WriteLine($"El porcentaje de revisión: {porcentajerev:F2}%");
        if (impactoAlto >= impactoMedio && impactoAlto >= impactoBajo)
        {
            predominante = "Alto";
        }
        else if (impactoMedio >= impactoAlto && impactoMedio >= impactoBajo)
        {
            predominante = "Medio";
        }
        else
        {
            predominante = "Bajo";
        }
        Console.WriteLine($"Impacto Predominante: {predominante}\n");
        Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
        Console.ReadKey();
        Console.Clear();
    }
    else
    {
        Console.WriteLine("No hay datos.\n");
        Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
        Console.ReadKey();
        Console.Clear();
    }
}

void Reinicio()//case 4
{
    Console.Clear();
    totalEvaluados = 0;
    publicados = 0;
    rechazados = 0;
    revision = 0;
    impactoAlto = 0;
    impactoMedio = 0;
    impactoBajo = 0;
    porcentajeAprov = 0;
    porcentajeRech = 0;
    Console.WriteLine("Estadísticas Reiniciadas.\n");
    Console.WriteLine("Presione ENTER o cualquier letra para continuar.\n");
    Console.ReadKey();
    Console.Clear();
}
void Salida()//Case 5
{
    Console.Clear();
    Console.WriteLine("   Resumen Final ");
    Console.WriteLine($"El nombre del contenido es: {nombre}");
    Console.WriteLine($"Contenido de Evaluados: {totalEvaluados}");
    Console.WriteLine($"Contenido de Publicados: {publicados}");
    Console.WriteLine($"Contenido de Rechazados: {rechazados}");
    Console.WriteLine($"Contenido En revisión: {revision}");
    if (totalEvaluados > 0)
    {
        porcentajeAprov = (publicados / totalEvaluados) * 100;
        porcentajeRech = (rechazados / totalEvaluados) * 100;
        porcentajerev = (revision / totalEvaluados) * 100;
        Console.WriteLine($"El porcentaje de Aprovación: {porcentajeAprov:F2}%");
        Console.WriteLine($"El porcentaje de Rechazados: {porcentajeRech:F2}%");
        Console.WriteLine($"El porcentaje de revisión: {porcentajerev:F2}%");
        Console.WriteLine($"Impacto predominante: {predominante}\n");
    }
    Console.WriteLine("Presione cualquier tecla para cerrar el programa.");
    Console.ReadKey();
}