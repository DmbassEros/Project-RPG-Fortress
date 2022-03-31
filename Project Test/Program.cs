using System;
using System.Threading;
using Tao.Sdl;

class Program
{
    static bool terminado;
    static Sprite personaje;
    static Sprite enemigo;
    static int x, y;
    static int xEmemy, yEmemy;
    static int velocidadEnemigo;
    static void Main(string[] args)
    {
        InicializarJuego();
        while (!terminado)
        {
            DibujarPantalla();
            ComprobarEntradaUsuario();
            AnimarElementos();
            ComprobarEntradaUsuario();
            PausarHastaFinDeFotograma();
        }
    }
    private static void InicializarJuego()
    {
        Hardware.Inicializar(1280, 720, 24);
        personaje = new Sprite("assets\\personajes/soldier.png");
        enemigo = new Sprite("assets\\enemigos/enemigo_soldier.png");
        terminado = false;
        x = 600;
        y = 300;
        xEmemy = 200;
        xEmemy = 250;
        velocidadEnemigo = 5;
    }
    private static void DibujarPantalla()
    {
        Hardware.BorrarPantallaOculta();
        personaje.MoverA(x, y);
        personaje.Dibujar();

        enemigo.MoverA(xEmemy, yEmemy);
        enemigo.Dibujar();

        Hardware.VisualizarOculta();
    }
    private static void ComprobarEntradaUsuario()
    {
        // movimientos
        if (Hardware.TeclaPulsada(Hardware.TECLA_IZQ))
            x -= 3;
        if (Hardware.TeclaPulsada(Hardware.TECLA_DER))
            x += 3;
        if (Hardware.TeclaPulsada(Hardware.TECLA_ARR))
            y -= 3;
        if (Hardware.TeclaPulsada(Hardware.TECLA_ABA))
            y += 3;

        if (Hardware.TeclaPulsada(Hardware.TECLA_ESC))
            terminado = true;
    }
    private static void AnimarElementos()
    {
        xEmemy = velocidadEnemigo;
    }
    private static void PausarHastaFinDeFotograma()
    {
        Hardware.Pausa(20);
    }
}
