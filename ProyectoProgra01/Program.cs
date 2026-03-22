//variables globales
int option = 0;
int tipo;
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
                break;
            case 2:
                break;
            case 3:
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
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
    }
}