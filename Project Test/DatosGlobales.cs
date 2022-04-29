using System;
class DatosGlobales
{
    public const int cantidadItems = 2;
    public const int cantidadZonas = 3;
    public static Random generador = new Random();
    public const int velocidadEnemigo = 5;
    public const int AnchoPersonaje = 52;
    public const int AltoPersonaje = 55;
    public const int AnchoyAltoItem = 51;
    public const int AnchoyAltoZona = 200;
    public const int PosXPersonaje = 70;
    public const int PosYPersonaje = 85;
    public static int Score = 0;
    public const int velocidad = 3;
    public static string[] Mapa =
    {
        "###################################",
        "#                              ####",
        "#                                 #",
        "#                                 #",
        "#                                 #",
        "#                                 #",
        "#                                 #",
        "#         -----┐                  #",
        "#              └┐                 #",
        "#         ┌-----┘                 #",
        "#         |                       #",
        "#         |                       #",
        "#         └-----                  #",
        "#                                 #",
        "#                                 #",
        "#                                 #",
        "#                                 #",
        "#                                 #",
        "#                                 #",
        "#####                             #",
        "#########                         #",
        "#########                        ##",
        "#########                        ##",
        "###################################",
    };
}

