using System;
using System.Threading;
using Tao.Sdl;

class Hardware
{
    // Atributos

    static IntPtr pantallaOculta;
    static int ancho, alto;

    // Operaciones

    /// Inicializa el modo grafico a un cierto ancho, alto y profundidad de color, p.ej. 640, 480, 24 bits
    public static void Inicializar(int an, int al, int colores)
    {
        //System.Console.Write("Inicializando...");
        ancho = an;
        alto = al;

        int flags = (Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT);
        Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
        pantallaOculta = Sdl.SDL_SetVideoMode(
            ancho,
            alto,
            colores,
            flags);

        Sdl.SDL_Rect rect2 =
            new Sdl.SDL_Rect(0, 0, (short)ancho, (short)alto);
        Sdl.SDL_SetClipRect(pantallaOculta, ref rect2);

        SdlTtf.TTF_Init();
    }

    /// Dibuja una imagen en pantalla oculta, en ciertas coordenadas
    public static void BorrarPantallaOculta()
    {
        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)ancho, (short)alto);
        Sdl.SDL_FillRect(pantallaOculta, ref origin, 0);
    }

    /// Dibuja una imagen en pantalla oculta, en ciertas coordenadas
    public static void DibujarImagenOculta(IntPtr imagen, int x, int y)
    {
        Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)ancho, (short)alto);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)ancho, (short)alto);
        Sdl.SDL_BlitSurface(imagen, ref origen, pantallaOculta, ref dest);
    }

    /// Dibuja una imagen en pantalla oculta, en ciertas coordenadas
    public static void DibujarImagenOculta(Imagen imagen, int x, int y)
    {
        DibujarImagenOculta(imagen.GetPuntero(), x, y);
    }

    /// Visualiza la pantalla oculta
    public static void VisualizarOculta()
    {
        Sdl.SDL_Flip(pantallaOculta);
    }


    public static IntPtr CargarImagen(string fichero)
    {
        IntPtr imagen;
        imagen = SdlImage.IMG_Load(fichero);
        if (imagen == IntPtr.Zero)
        {
            System.Console.WriteLine("Imagen inexistente: {0}", fichero);
            Environment.Exit(4);
        }
        return imagen;
    }

    public static void EscribirTextoOculta(string texto,
        int x, int y, byte r, byte g, byte b, Fuente f)
    {
        EscribirTextoOculta(texto, x, y, r, g, b, f.LeerPuntero());
    }

    public static void EscribirTextoOculta(string texto,
        int x, int y, byte r, byte g, byte b, IntPtr fuente)
    {
        Sdl.SDL_Color color = new Sdl.SDL_Color(r, g, b);
        IntPtr textoComoImagen = SdlTtf.TTF_RenderText_Solid(
            fuente, texto, color);
        if (textoComoImagen == IntPtr.Zero)
            Environment.Exit(5);

        Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)ancho, (short)alto);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)ancho, (short)alto);

        Sdl.SDL_BlitSurface(textoComoImagen, ref origen,
            pantallaOculta, ref dest);
        Sdl.SDL_FreeSurface(textoComoImagen);
    }

    public static IntPtr CargarFuente(string fichero, int tamanyo)
    {
        IntPtr fuente = SdlTtf.TTF_OpenFont(fichero, tamanyo);
        if (fuente == IntPtr.Zero)
        {
            System.Console.WriteLine("Fuente inexistente: {0}", fichero);
            Environment.Exit(6);
        }
        return fuente;
    }

    public static bool TeclaPulsada(int c)
    {
        bool pulsada = false;
        Sdl.SDL_PumpEvents();
        Sdl.SDL_Event suceso;
        Sdl.SDL_PollEvent(out suceso);
        int numkeys;
        byte[] teclas = Tao.Sdl.Sdl.SDL_GetKeyState(out numkeys);
        if (teclas[c] == 1)
            pulsada = true;
        return pulsada;
    }

    public static void Pausa(int milisegundos)
    {
        Thread.Sleep(milisegundos);
    }

    /// Devuelve la anchura de la pantalla, en pixeles
    public static int GetAncho()
    {
        return ancho;
    }

    /// Devuelve la altura de la pantalla, en pixeles
    public static int GetAlto()
    {
        return alto;
    }

    /// Abandona el programa, mostrando un cierto mensaje de error
    public static void ErrorFatal(string texto)
    {
        System.Console.WriteLine(texto);
        Environment.Exit(1);
    }
    // Teclas a usar en el programa
    public static int TECLA_ESC = Sdl.SDLK_ESCAPE;
    public static int TECLA_ESP = Sdl.SDLK_SPACE;
    public static int TECLA_ARR = Sdl.SDLK_UP;
    public static int TECLA_ABA = Sdl.SDLK_DOWN;
    public static int TECLA_DER = Sdl.SDLK_RIGHT;
    public static int TECLA_IZQ = Sdl.SDLK_LEFT;
}
