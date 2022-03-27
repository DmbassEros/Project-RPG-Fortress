using System;
using System.Threading;
using Tao.Sdl;

class Program
{
    static bool terminado;
    static Sprite personaje;
    static int x, y;
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
        personaje = new Sprite("datos\\soldier.png");
        terminado = false;
        x = 600;
        y = 300;
    }
    private static void DibujarPantalla()
    {
        Hardware.BorrarPantallaOculta();
        personaje.MoverA(x, y);
        personaje.Dibujar();

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

    }
    private static void PausarHastaFinDeFotograma()
    {
        Hardware.Pausa(20);
    }
}
