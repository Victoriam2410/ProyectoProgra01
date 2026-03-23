//variables globales
int option = 0;
int tipo;
int duracionPeli;
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
string predominante = null;
double porcentajeAprov = 0;
double porcentajeRech = 0;
MenuPrincipal();
//inicio del menu
void MenuPrincipal()
{
do
    {
        Console.WriteLine("  SIMULADOR DE DECISIONES PARA PLATAFORMA DE STREAMING\n ");
        Console.WriteLine("             Menú Principal  ");
        Console.WriteLine("Bienvenido al menú principal");
        Console.WriteLine("¿sCuál de las opciones desea elejir?");
        Console.WriteLine("\n1.Evaluar Contenido\n 2.Politicas\n 3.Estadisticas\n 4.Reiniciar Estadisticas\n 5.Salir.");
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
                break;
            case 5:
                break;
        }
    } while (option != 5) ;
}
void PedirDatos()
{
    Console.WriteLine("Ingrese el tipo de contenido (1.película, 2.serie, 3.documental, 4.evento en vivo):");
    while (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 1 || tipo > 4)
    {
        Console.WriteLine("Error: Ingrese las opciones validas. (1, 2, 3, 4):");
    }
    switch (tipo)
    {
        case 1:
            ValidacionDatosP();
            break;
        case 2:
            ValidacionDatoS();
            break;
        case 3:
            ValidarDatosD();
            break;
        case 4:
            ValidacionDatosE();
            break;
    }
}
void ValidacionDatosP() //pelicula
{
    Console.WriteLine("Ingrese el nombre de la película:");
    string nombrePelicula = Console.ReadLine();

    Console.WriteLine("¿Cuál es la duración de la película? (60-180 min):");
    while (!int.TryParse(Console.ReadLine(), out duracionPeli) || duracionPeli < 60 || duracionPeli > 180)
    {
        Console.WriteLine("Error: Ingrese una duración válida para película (60-180 min):");
    }
    cumpleDuracion = true;

    Console.WriteLine("ingrese la clasificación ( 1.- todo público, 2.- +13, 3.- +18 ):");
    int clasificacionUNO;
    while (!int.TryParse(Console.ReadLine(), out clasificacionUNO) || clasificacionUNO < 1 || clasificacionUNO > 3)
    {
        Console.WriteLine("Error: Ingrese clasificación valida:");
    }

    Console.WriteLine("Ingrese la hora programada (0-23):");
    int horaUno;
    while (!int.TryParse(Console.ReadLine(), out horaUno) || horaUno < 0 || horaUno > 23)
    {
        Console.WriteLine("Error: Ingrese una hora válida (0-23):");
    }

    if (clasificacionUNO == 1)
    {
        cumpleHora = true;
    }
    else if (clasificacionUNO == 2)
    {
        if (horaUno >= 6 && horaUno <= 22)
        {
            cumpleHora = true;
        }
        else
        {
            cumpleHora = false;
        }
    }
    else if (clasificacionUNO == 3)
    {
        if (horaUno >= 22 || horaUno <= 5)
        {
            cumpleHora = true;
        }
        else
        {
            cumpleHora = false;
        }
    }

    Console.WriteLine("Nivel de Producción (1.bajo, 2.medio, 3.alto)_");
    int produccionUno;
    while (!int.TryParse(Console.ReadLine(), out produccionUno) || produccionUno < 1 || produccionUno > 3)
    {
        Console.WriteLine("Error: Ingrese un nivel válido.\n");
    }

    if (produccionUno == 1 && clasificacionUNO == 3)
    {
        cumpleProduccion = false;
    }
    else
    {
        cumpleProduccion = true;
    }

    Console.WriteLine("\nResultado de la Evaluación ");
    totalEvaluados++;
    if (cumpleDuracion && cumpleHora && cumpleProduccion)
    {
        if (produccionUno == 3 || duracionPeli > 120 || (horaUno >= 20 && horaUno <= 23))
        {
            impactoAlto++;
            revision++;
            Console.WriteLine("Estado: Enviar a revisión");
            Console.WriteLine("Razón: Cumple reglas pero tiene impacto Alto.\n");
            Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
            Console.ReadKey();
        }
        else if (produccionUno == 2 || (duracionPeli >= 60 && duracionPeli <= 120))
        {
            impactoMedio++;
            publicados++;
            Console.WriteLine("Estado: Publicar");
            Console.WriteLine("Razón: Cumple reglas y tiene impacto Medio.\n");
            Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
            Console.ReadKey();
        }
        else
        {
            impactoBajo++;
            publicados++;
            Console.WriteLine("Estado: Publicar");
            Console.WriteLine("Razón: El contenido tiene impacto Bajo");
            Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
            Console.ReadKey();
        }
    }
    else
    {
        rechazados++;
        Console.WriteLine("Estado: Rechazar");
        if (!cumpleHora) Console.WriteLine("El horario no es apto para la clasificación.");
        if (!cumpleProduccion) Console.WriteLine("Producción baja no permitida para la clasificación.\n");
        Console.WriteLine("Precione ENTER o cualquier letra para ir al menú");
        Console.ReadKey();
    }
}
void ValidacionDatoS() //Serie
{
    Console.WriteLine("Ingrese el nombre de la Serie:");
    string nombreSerie = Console.ReadLine();

    Console.WriteLine("¿Cual es la duración de la Serie? (20-90 min):");
    int duracionSerie;
    while (!int.TryParse(Console.ReadLine(), out duracionSerie) || duracionSerie < 20 || duracionSerie > 90)
    {
        Console.WriteLine("Error: Ingrese una duración válida para serie (20-90 min):");
    }
    cumpleDuracion = true;

    Console.WriteLine("ingrese la clasificación ( 1.- todo público, 2.- +13, 3.- +18 )");
    int clasificacionDOS;
    while (!int.TryParse(Console.ReadLine(), out clasificacionDOS) || clasificacionDOS < 1 || clasificacionDOS > 3)
    {
        Console.WriteLine("Error: Ingrese clasificación valida.");
    }

    Console.WriteLine("Ingrese la hora programada (0-23):");
    int horaDos;
    while (!int.TryParse(Console.ReadLine(), out horaDos) || horaDos < 0 || horaDos > 23)
    {
        Console.WriteLine("Error: Ingrese una hora válida (0-23):");
    }

    if (clasificacionDOS == 1)
    {
        cumpleHora = true;
    }
    else if (clasificacionDOS == 2)
    {
        if (horaDos >= 6 && horaDos <= 22)
        {
            cumpleHora = true;
        }
        else
        {
            cumpleHora = false;
        }
    }
    else if (clasificacionDOS == 3)
    {
        if (horaDos >= 22 || horaDos <= 5)
        {
            cumpleHora = true;
        }
        else
        {
            cumpleHora = false;
        }
    }

    Console.WriteLine("Nivel de Producción (1.bajo, 2.medio, 3.alto)");
    int produccionDos;
    while (!int.TryParse(Console.ReadLine(), out produccionDos) || produccionDos < 1 || produccionDos > 3)
    {
        Console.WriteLine("Error: Ingrese un nivel válido.");
    }

    if (produccionDos == 1 && clasificacionDOS == 3)
    {
        cumpleProduccion = false;
    }
    else
    {
        cumpleProduccion = true;
    }

    Console.WriteLine("\n  Resultado de la Evaluación ");
    totalEvaluados++;

    if (cumpleDuracion && cumpleHora && cumpleProduccion)
    {
        if (produccionDos == 3 || duracionSerie > 120 || (horaDos >= 20 && horaDos <= 23))
        {
            impactoAlto++;
            revision++;
            Console.WriteLine("Estado: ENVIAR A REVISIÓN");
            Console.WriteLine("Razón: El contenido tiene impacto ALTO.\n");
            Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
            Console.ReadKey();
        }
        else if (produccionDos == 2 || (duracionSerie >= 60 && duracionSerie <= 120))
        {
            impactoMedio++;
            publicados++;
            Console.WriteLine("Estado: Publicar");
            Console.WriteLine("Razón: El contenido tiene impacto MEDIO.\n");
            Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
            Console.ReadKey();
        }
        else
        {
            impactoBajo++;
            publicados++;
            Console.WriteLine("Estado: Publicar");
            Console.WriteLine("Razón: El contenido tiene impacto BAJO.\n");
            Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
            Console.ReadKey();
        }
    }
    else
    {
        rechazados++;
        Console.WriteLine("Estado: Rechazar");
        if (!cumpleHora) Console.WriteLine("Razón: El horario no es apto para la clasificación.");
        if (!cumpleProduccion) Console.WriteLine("Razón: Producción baja no permitida para la clasificación.\n");
        Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
        Console.ReadKey();
    }
}
void ValidarDatosD() //Documental
{
    Console.WriteLine("Ingrese el nombre del Documental:");
    string nombreDocumental = Console.ReadLine();

    Console.WriteLine("¿Cual es la duración del Documental? (30-120 min):");
    int duracionDocu;
    while (!int.TryParse(Console.ReadLine(), out duracionDocu) || duracionDocu < 30 || duracionDocu > 120)
    {
        Console.WriteLine("Error: Ingrese una duración válida para documental (30-120 min):");
    }
    cumpleDuracion = true;

    Console.WriteLine("ingrese la clasificación ( 1.- todo público, 2.- +13, 3.- +18 )");
    int clasificacionTres;
    while (!int.TryParse(Console.ReadLine(), out clasificacionTres) || clasificacionTres < 1 || clasificacionTres > 3)
    {
        Console.WriteLine("Error: Ingrese clasificación valida.");
    }

    Console.WriteLine("Ingrese la hora programada (0-23):");
    int horaTres;
    while (!int.TryParse(Console.ReadLine(), out horaTres) || horaTres < 0 || horaTres > 23)
    {
        Console.WriteLine("Error: Ingrese una hora válida (0-23):");
    }

    if (clasificacionTres == 1)
    {
        cumpleHora = true;
    }
    else if (clasificacionTres == 2)
    {
        if (horaTres >= 6 && horaTres <= 22)
        {
            cumpleHora = true;
        }
        else
        {
            cumpleHora = false;
        }
    }
    else if (clasificacionTres == 3)
    {
        if (horaTres >= 22 || horaTres <= 5)
        {
            cumpleHora = true;
        }
        else
        {
            cumpleHora = false;
        }
    }


    Console.WriteLine("Nivel de Producción (1.bajo, 2.medio, 3.alto)");
    int produccionTres;
    while (!int.TryParse(Console.ReadLine(), out produccionTres) || produccionTres < 1 || produccionTres > 3)
    {
        Console.WriteLine("Error: Ingrese un nivel válido.");
    }

    if (produccionTres == 1 && clasificacionTres == 3)
    {
        cumpleProduccion = false;
    }
    else
    {
        cumpleProduccion = true;
    }

    Console.WriteLine("\n   Resultado de la Evaluación   ");
    totalEvaluados++;

    if (cumpleDuracion && cumpleHora && cumpleProduccion)
    {
        if (produccionTres == 3 || (horaTres >= 20 && horaTres <= 23))
        {
            revision++;
            impactoAlto++;
            Console.WriteLine("Estado: ENVIAR A REVISIÓN");
            Console.WriteLine("Razón: Cumple reglas pero tiene impacto alto.\n");
            Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
            Console.ReadKey();
        }
        else if (produccionTres == 2)
        {
            publicados++;
            impactoMedio++;
            Console.WriteLine("Estado: Publicar");
            Console.WriteLine("Razón: Cumple reglas e impacto medio.\n");
            Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
            Console.ReadKey();
        }
        else
        {
            publicados++;
            impactoBajo++;
            Console.WriteLine("Estado: Publicar");
            Console.WriteLine("Razón: Cumple reglas e impacto bajo.\n");
            Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
            Console.ReadKey();
        }
    }
    else
    {
        rechazados++;
        Console.WriteLine("Estado: Rechazar");
        if (!cumpleHora) Console.WriteLine("El horario no es apto para la clasificación.\n");
        if (!cumpleProduccion) Console.WriteLine("Producción baja no permitida para la clasificación.\n");
        Console.WriteLine("Presione ENTER o cualquier letra para ir al menú.\n");
        Console.ReadKey();
    }
}
void ValidacionDatosE()//envivo
{
    Console.WriteLine("Ingrese el nombre del evento en vivo:");
    string nombreEvento = Console.ReadLine();

    Console.WriteLine("¿Cual es la duración del evento en vivo? (30-240 min):");
    int duracionEvento;
    while (!int.TryParse(Console.ReadLine(), out duracionEvento) || duracionEvento < 30 || duracionEvento > 240)
    {
        Console.WriteLine("Error: Ingrese una duración válida para evento en vivo (30-240 min):");
    }
    cumpleDuracion = true;

    Console.WriteLine("ingrese la clasificación ( 1.- todo público, 2.- +13, 3.- +18 )");
    int clasificacionCuatro;
    while (!int.TryParse(Console.ReadLine(), out clasificacionCuatro) || clasificacionCuatro < 1 || clasificacionCuatro > 3)
    {
        Console.WriteLine("Error: Ingrese clasificación valida.");
    }

    Console.WriteLine("Ingrese la hora programada (0-23):");
    int horaCuatro;
    while (!int.TryParse(Console.ReadLine(), out horaCuatro) || horaCuatro < 0 || horaCuatro > 23)
    {
        Console.WriteLine("Error: Ingrese una hora válida (0-23):");
    }

    if (clasificacionCuatro == 1)
    {
        cumpleHora = true;
    }
    else if (clasificacionCuatro == 2)
    {
        if (horaCuatro >= 6 && horaCuatro <= 22)
        {
            cumpleHora = true;
        }
        else
        {
            cumpleHora = false;
        }
    }
    else if (clasificacionCuatro == 3)
    {
        if (horaCuatro >= 22 || horaCuatro <= 5)
        {
            cumpleHora = true;
        }
        else
        {
            cumpleHora = false;
        }
    }

    Console.WriteLine("Nivel de Producción (1.bajo, 2.medio, 3.alto)");
    int produccionCuatro;
    while (!int.TryParse(Console.ReadLine(), out produccionCuatro) || produccionCuatro < 1 || produccionCuatro > 3)
    {
        Console.WriteLine("Error: Ingrese un nivel válido.");
    }

    if (produccionCuatro == 1 && clasificacionCuatro == 3)
    {
        cumpleProduccion = false;
    }
    else
    {
        cumpleProduccion = true;
    }

    Console.WriteLine("\n  Resultado de la Evaluación ");
    totalEvaluados++;

    if (cumpleDuracion && cumpleHora && cumpleProduccion)
    {
        if (produccionCuatro == 3 || duracionEvento > 120 || (horaCuatro >= 20 && horaCuatro <= 23))
        {
            revision++;
            impactoAlto++;
            Console.WriteLine("Estado: ENVIAR A REVISIÓN");
            Console.WriteLine("Razón: Cumple reglas pero tiene impacto alto.");
            Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
            Console.ReadKey();
        }
        else if (produccionCuatro == 2)
        {
            publicados++;
            impactoMedio++;
            Console.WriteLine("Estado: Publicar");
            Console.WriteLine("Razón: Cumple reglas e impacto medio.");
            Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
            Console.ReadKey();
        }
        else
        {
            publicados++;
            impactoBajo++;
            Console.WriteLine("Estado: Publicar");
            Console.WriteLine("Razón: Cumple reglas e impacto bajo.");
            Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
            Console.ReadKey();
        }
    }
    else
    {
        rechazados++;
        Console.WriteLine("Estado: Rechazar");
        if (!cumpleHora) Console.WriteLine("El horario no es apto para la clasificación.");
        if (!cumpleProduccion) Console.WriteLine("Producción baja no permitida para la clasificación.\n");
        Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
        Console.ReadKey();
    }
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
}
void Estadisticas()//Case3
{
    Console.Clear();
    if (totalEvaluados > 0)
    {
        Console.WriteLine($"El total de evaluados es: {totalEvaluados}");
        Console.WriteLine($"El total de publicados es: {publicados}");
        Console.WriteLine($"El total de rechazados es: {rechazados}");
        if (totalEvaluados > 0)
        {
            porcentajeAprov = (publicados / totalEvaluados) * 100;
            porcentajeRech = (rechazados / totalEvaluados) * 100;
            Console.WriteLine($"El porcentaje de aprovados es: {porcentajeAprov:F2}%");
            Console.WriteLine($"El porcentaje de Rechazados es: {porcentajeRech:F2}%");
            if (impactoAlto == impactoMedio && impactoAlto == impactoBajo && impactoMedio == impactoBajo)
            {
                predominante = "Empate Total";
            }
            else if (impactoAlto >= impactoMedio && impactoAlto >= impactoBajo)
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
        }
        else
        {
            Console.WriteLine("No hay datos registrados en esta sesión.");
            Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
            Console.ReadKey();
        }
        Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Aún no hay datos registrados.\n");
        Console.WriteLine("Presione ENTER o cualquier tecla para continuar.\n");
        Console.ReadKey();
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
    Console.WriteLine("Estadísticas Reiniciadas.");
    Console.WriteLine("Presione ENTER o cualquier letra para continuar.\n");
    Console.ReadKey();
}
void Salida()//Case 5
{
    Console.Clear();
    Console.WriteLine("   Resumen Final ");
    Console.WriteLine($"Contenido de Evaluados: {totalEvaluados}");
    Console.WriteLine($"Contenido de publicados: {publicados}");
    Console.WriteLine($"Contenido de rechazados: {rechazados}");
    if (totalEvaluados > 0)
    {
        porcentajeAprov = (publicados / totalEvaluados) * 100;
        porcentajeRech = (rechazados / totalEvaluados) * 100;
        Console.WriteLine($"El porcentaje de aprovación: {porcentajeAprov:F2}%");
        Console.WriteLine($"El porcentaje de Rechazados: {porcentajeRech:F2}%");
        Console.WriteLine($"Impacto predominante: {predominante}");
    }
    Console.WriteLine("Presione cualquier tecla para cerrar el programa.");
    Console.ReadKey();
}