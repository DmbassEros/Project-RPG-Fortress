using System;
class DatosGlobales
{
    public enum ESCENA { MAPA, COMBATE };
    public enum TIPOCOMBATE{ ZONA1 ,ZONA2 , ZONA3, ZONA4 };
    public enum COLOR { ROJO, AZUL };
    public enum EFECTO { ATACAR, CURAR };
    public const int cantidadItems = 2;
    public const int CANTIDADZONAS = 3;
    public static Random GENERADOR = new Random();
    public const int VELOCIDADENEMIGO = 5;
    public const int ANCHOPERSONAJE = 52;
    public const int ALTOPERSONAJE = 55;
    public const int ANCHOPERSONAJE_COMBAT = 200;
    public const int ALTOPERSONAJE_COMBAT = 348;
    public const int ANCHOYALTOITEM = 51;
    public const int ANCHOYALTOZONA = 200;
    public const int POSXPERSONAJE = 70;
    public const int POSYPERSONAJE = 85;
    public const int POSXPERSONAJE_COMBAT = 200;
    public const int POSYPERSONAJE_COMBAT = 300;
    public const int POSXENEMIGO_COMBAT = 1000;
    public const int POSYENEMIGO_COMBAT = 450;
    public static int SCORE = 0;
    public const int VELOCIDAD = 5;
    public static Fuente LETRA_MAIN = new Fuente("assets\\fuentes/tf2build.ttf", 22);
    public static Fuente LETRA_TITLE = new Fuente("assets\\fuentes/tf2build.ttf", 40);
    public static Fuente LETRA_COMBATE;
    public static Fuente LETRA_ENEMIGO;
    public static int FOTOGRAMAS = 5;
    public static Sonido ITEM_RECOGIDO = new Sonido("assets\\sonidos/ui/item_bag_pickup.wav");
    public static Sonido SONIDOFONDO = new Sonido("assets\\sonidos/Playing With Danger.mp3");
    public static Sonido SONIDOCOMBATE = new Sonido("assets\\sonidos/Intruder Alert.mp3");
    public static Sonido INTRO_MENU = new Sonido("assets\\sonidos/ui/mm_round_start_casual.wav");
    public static string[] MAPA =
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

