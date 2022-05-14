using static DatosGlobales;
using Tao.Sdl;
using System;

class Menu
{
    private Imagen fondoMenu;

    static bool bienvenidaTerminada;
    static Imagen fondoBienvenida;
    static Imagen fondoTutorial;

    public Menu()
    {
        DatosGlobales.LETRA_MAIN = new Fuente("assets\\fuentes/tf2build.ttf", 22);
        DatosGlobales.LETRA_TITLE = new Fuente("assets\\fuentes/tf2build.ttf", 40);
        fondoMenu = new Imagen("assets\\escenas/fondoBienvenida.png");
        bienvenidaTerminada = false;
    }
    public void Start()
    {
        BucleMenu();
    }
    void BucleMenu()
    {
        DatosGlobales.INTRO_MENU.Reproducir1();
        do
        {
            DibujarPantalla();
            ComprobarEntradaUsuario();
            PausarHastaFinDeFotograma();
        }
        while (!bienvenidaTerminada);
    }
    private void DibujarPantalla()
    {
        Hardware.BorrarPantallaOculta();
        fondoMenu.Dibujar(0, 0);
        MostrarBienvenida();
        Hardware.VisualizarOculta();
    }
    private void ComprobarEntradaUsuario()
    {

        do
        {
            if (Hardware.TeclaPulsada(Hardware.TECLA_1))
            {
                Program.TerminarPartida();
                bienvenidaTerminada = true;
            }
            if (Hardware.TeclaPulsada(Hardware.TECLA_3))
            {
                bienvenidaTerminada = true;
            }
            if (Hardware.TeclaPulsada(Hardware.TECLA_ESC))
            {
                Sdl.SDL_Quit();
                Environment.Exit(1);
            }
            Hardware.Pausa(20);
        }
        while (!bienvenidaTerminada);
    }
    private void MostrarBienvenida()
    {
        bienvenidaTerminada = false;
        fondoBienvenida = new Imagen();
        Hardware.DibujarImagenOculta(fondoBienvenida, 0, 0);

        Hardware.EscribirTextoOculta("R P G - F O R T R E S S", 415, 150, 163, 94, 34,
            DatosGlobales.LETRA_TITLE);
        Hardware.EscribirTextoOculta("R P G - F O R T R E S S", 410, 150, 234, 173, 9,
            DatosGlobales.LETRA_TITLE);


        Hardware.EscribirTextoOculta("1. Partida Nueva", 300, 250, 252, 199, 0,
            DatosGlobales.LETRA_MAIN);
        Hardware.EscribirTextoOculta("2. Cargar Partida", 300, 300, 252, 199, 0,
            DatosGlobales.LETRA_MAIN);
        Hardware.EscribirTextoOculta("3. Continuar Partida", 300, 350, 252, 199, 0,
        DatosGlobales.LETRA_MAIN);
        Hardware.EscribirTextoOculta("4. Tutorial / Controles", 300, 400, 252, 199, 0,
            DatosGlobales.LETRA_MAIN);
        Hardware.EscribirTextoOculta("ESC. Salir", 300, 450, 252, 199, 0,
            DatosGlobales.LETRA_MAIN);
        Hardware.VisualizarOculta();
    }
    private void MostrarTutorial()
    {
        
    }
    private void PausarHastaFinDeFotograma()
    {
        Hardware.Pausa(20);
    }
}
