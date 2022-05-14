using System;
using System.Threading;

class Program
{
    static bool sesionTerminada;
    static bool partidaTerminada;
    static Sprite personaje;
    static Sprite[] items;
    static Sprite[] zonas;
    static int x, y;
    static Sprite[,] paredes;
    static Sprite[,] fondo;
    static int xMapa = 1, yMapa = 1 ;
    static int anchoTile = 30, altoTile = 30;
    static string texturaFondo;


    static void Main(string[] args)
    {
        InicializarSesion();
        do
        {
            if (!sesionTerminada)
            {
                InicializarJuego();
                while (!partidaTerminada)
                {
                    DibujarPantalla();
                    AnimarElementos();
                    ComprobarEntradaUsuario();
                    ComprobarEstadoDelJuego();
                    PausarHastaFinDeFotograma();
                }
            }
        }
        while (!sesionTerminada);
    }
    private static void InicializarSesion()
    {
        Hardware.Inicializar(1280, 720, 24);
        sesionTerminada = false;
        InicializarMenu();
    }
    private static void InicializarMenu()
    {
        Menu menu = new Menu();
        menu.Start();
    }
    private static void InicializarJuego()
    {
        personaje = new Sprite("assets\\personajes/down_soldier_2.png");
        AnimarElementos();
        DatosGlobales.SONIDOFONDO.ReproducirFondo();

        personaje.SetAnchoAlto(DatosGlobales.ANCHOPERSONAJE,
            DatosGlobales.ALTOPERSONAJE);
        x = DatosGlobales.POSXPERSONAJE;
        y = DatosGlobales.POSYPERSONAJE;


        items = new Sprite[DatosGlobales.cantidadItems];
        for (int i = 0; i < DatosGlobales.cantidadItems; i++)
        {
            items[i] = new Sprite("assets\\items/ammo.png");
            items[i].MoverA(
                DatosGlobales.GENERADOR.Next(0, 650),
                 DatosGlobales.GENERADOR.Next(0, 300));
        items[i].SetAnchoAlto(DatosGlobales.ANCHOYALTOITEM,
            DatosGlobales.ANCHOYALTOITEM);
        }
        zonas = new Sprite[DatosGlobales.CANTIDADZONAS];
        for (int i = 0; i < DatosGlobales.CANTIDADZONAS; i++)
        {
            zonas[i] = new Sprite("assets\\estructura/zona" +
                DatosGlobales.GENERADOR.Next(1, 4) + ".png");
            zonas[i].MoverA(
                DatosGlobales.GENERADOR.Next(250, 1000),
                 DatosGlobales.GENERADOR.Next(300, 450));
            zonas[i].SetAnchoAlto(DatosGlobales.ANCHOYALTOZONA,
                DatosGlobales.ANCHOYALTOZONA);
        }
        partidaTerminada = false;

        
        paredes = new Sprite[DatosGlobales.MAPA.Length,
            DatosGlobales.MAPA[0].Length];
        for (int fila = 0; fila < DatosGlobales.MAPA.Length; fila++)
        {
            for (int columna = 0; columna < 
                DatosGlobales.MAPA[0].Length;columna++)
            {
                if (DatosGlobales.MAPA[fila][columna] == '#')
                {
                    paredes[fila, columna] = 
                        new Sprite("assets\\estructura/borde.png");
                    paredes[fila, columna].MoverA(
                    xMapa + columna * anchoTile,
                    yMapa + fila * altoTile);
                    paredes[fila, columna].SetAnchoAlto(anchoTile, altoTile);
                }
            }
        }
        fondo = new Sprite[DatosGlobales.MAPA.Length,
            DatosGlobales.MAPA[0].Length];
        for (int fila = 0; fila < DatosGlobales.MAPA.Length; fila++)
        {
            for (int columna = 0; columna <
                DatosGlobales.MAPA[0].Length; columna++)
            {
                texturaFondo = DatosGlobales.MAPA[fila][columna].ToString();
                switch (texturaFondo)
                {
                    case "-":
                        fondo[fila, columna] =
                        new Sprite("assets\\estructura/camino1.png");
                        fondo[fila, columna].MoverA(
                        xMapa + columna * anchoTile,
                        yMapa + fila * altoTile);
                        fondo[fila, columna].SetAnchoAlto(anchoTile, altoTile);
                        break;
                    case "└":
                        fondo[fila, columna] =
                        new Sprite("assets\\estructura/camino2.png");
                        fondo[fila, columna].MoverA(
                        xMapa + columna * anchoTile,
                        yMapa + fila * altoTile);
                        fondo[fila, columna].SetAnchoAlto(anchoTile, altoTile);
                        break;
                    case "┌":
                        fondo[fila, columna] =
                        new Sprite("assets\\estructura/camino2_1.png");
                        fondo[fila, columna].MoverA(
                        xMapa + columna * anchoTile,
                        yMapa + fila * altoTile);
                        fondo[fila, columna].SetAnchoAlto(anchoTile, altoTile);
                        break;
                    case "┐":
                        fondo[fila, columna] =
                        new Sprite("assets\\estructura/camino2_2.png");
                        fondo[fila, columna].MoverA(
                        xMapa + columna * anchoTile,
                        yMapa + fila * altoTile);
                        fondo[fila, columna].SetAnchoAlto(anchoTile, altoTile);
                        break;
                    case "┘":
                        fondo[fila, columna] =
                        new Sprite("assets\\estructura/camino2_3.png");
                        fondo[fila, columna].MoverA(
                        xMapa + columna * anchoTile,
                        yMapa + fila * altoTile);
                        fondo[fila, columna].SetAnchoAlto(anchoTile, altoTile);
                        break;
                    case "|":
                        fondo[fila, columna] =
                        new Sprite("assets\\estructura/camino3.png");
                        fondo[fila, columna].MoverA(
                        xMapa + columna * anchoTile,
                        yMapa + fila * altoTile);
                        fondo[fila, columna].SetAnchoAlto(anchoTile, altoTile);
                        break;
                }
                if (DatosGlobales.MAPA[fila][columna] == '╗')
                {
                    fondo[fila, columna] =
                        new Sprite("assets\\estructura/camino2_2.png");
                    fondo[fila, columna].MoverA(
                    xMapa + columna * anchoTile,
                    yMapa + fila * altoTile);
                    fondo[fila, columna].SetAnchoAlto(anchoTile, altoTile);
                }
            }
        }

    }
    private static void DibujarPantalla()
    {
        Hardware.BorrarPantallaOculta();
       
        
        for (int fila = 0; fila < DatosGlobales.MAPA.Length; fila++)
        {
            for (int columna = 0; columna <
                DatosGlobales.MAPA[0].Length; columna++)
            {
                if (paredes[fila,columna] != null)
                {
                    paredes[fila, columna].Dibujar();
                }
            }
        }
        for (int fila = 0; fila < DatosGlobales.MAPA.Length; fila++)
        {
            for (int columna = 0; columna <
                DatosGlobales.MAPA[0].Length; columna++)
            {
                if (fondo[fila, columna] != null)
                {
                    fondo[fila, columna].Dibujar();
                }
            }
        }
        for (int i = 0; i < DatosGlobales.CANTIDADZONAS; i++)
        {
            zonas[i].Dibujar();
        }
        for (int i = 0; i < DatosGlobales.cantidadItems; i++)
        {
            items[i].Dibujar();
        }
        personaje.MoverA(x, y);
        personaje.Dibujar();
        Hardware.EscribirTextoOculta("Equipo " + DatosGlobales.SCORE,
            1100, 10, 255, 153, 51, DatosGlobales.LETRA_MAIN);
        Hardware.EscribirTextoOculta("solly", 1100, 35, 255, 153,
            51, DatosGlobales.LETRA_MAIN);
        Hardware.VisualizarOculta();
    }
    private static void ComprobarEntradaUsuario()
    {
        // Movimientos
        // Izquierda
        if ((Hardware.TeclaPulsada(Hardware.TECLA_IZQ))
                && EsPosibleMoverA(x - DatosGlobales.VELOCIDAD, y,
                x + DatosGlobales.ANCHOPERSONAJE - DatosGlobales.VELOCIDAD,
                y + DatosGlobales.ALTOPERSONAJE))
        { 
            x -= DatosGlobales.VELOCIDAD;
            personaje.CambiarDireccion(Sprite.IZQUIERDA);
            DatosGlobales.FOTOGRAMAS--;
            if (DatosGlobales.FOTOGRAMAS <= 0)
            {
                DatosGlobales.FOTOGRAMAS = 5;
                personaje.SiguienteFotograma();
            }
        }
        // Derecha
        if ((Hardware.TeclaPulsada(Hardware.TECLA_DER))
                && EsPosibleMoverA(x + DatosGlobales.VELOCIDAD, y,
                x + DatosGlobales.ANCHOPERSONAJE + DatosGlobales.VELOCIDAD,
                y + DatosGlobales.ALTOPERSONAJE))
        {
            x += DatosGlobales.VELOCIDAD;
            personaje.CambiarDireccion(Sprite.DERECHA);
            DatosGlobales.FOTOGRAMAS--;
            if (DatosGlobales.FOTOGRAMAS <= 0)
            {
                DatosGlobales.FOTOGRAMAS = 5;
                personaje.SiguienteFotograma();
            }
        }
        // Arriba
        if ((Hardware.TeclaPulsada(Hardware.TECLA_ARR))
             && EsPosibleMoverA(x, y - DatosGlobales.VELOCIDAD,
             x + DatosGlobales.ANCHOPERSONAJE,
             y + DatosGlobales.ALTOPERSONAJE - DatosGlobales.VELOCIDAD))
        {
            y -= DatosGlobales.VELOCIDAD;
            personaje.CambiarDireccion(Sprite.ARRIBA);
            DatosGlobales.FOTOGRAMAS--;
            if (DatosGlobales.FOTOGRAMAS <= 0)
            {
                DatosGlobales.FOTOGRAMAS = 5;
                personaje.SiguienteFotograma();
            }
        }
        // Abajo
        if ((Hardware.TeclaPulsada(Hardware.TECLA_ABA))
                && EsPosibleMoverA(x, y + DatosGlobales.VELOCIDAD,
                x + DatosGlobales.ANCHOPERSONAJE,
                y + DatosGlobales.ALTOPERSONAJE + DatosGlobales.VELOCIDAD))
        {
            y += DatosGlobales.VELOCIDAD;
            personaje.CambiarDireccion(Sprite.ABAJO);
            DatosGlobales.FOTOGRAMAS--;
            if (DatosGlobales.FOTOGRAMAS <= 0)
            {
                DatosGlobales.FOTOGRAMAS = 5;
                personaje.SiguienteFotograma();
            }
            
        }

        if (Hardware.TeclaPulsada(Hardware.TECLA_ESC))
        {
            Thread.Sleep(250);
            Menu menuAcargar = new Menu();
            menuAcargar.Start();
        }


    }
    private static void AnimarElementos()
    {
        personaje.CargarSecuencia(Sprite.DERECHA,
            new string[] { "assets\\personajes/right_soldier_1.png"
            , "assets\\personajes/right_soldier_2.png",
                "assets\\personajes/right_soldier_3.png" });
        personaje.CargarSecuencia(Sprite.IZQUIERDA,
           new string[] { "assets\\personajes/left_soldier_1.png"
            , "assets\\personajes/left_soldier_2.png",
                "assets\\personajes/left_soldier_3.png" });
        personaje.CargarSecuencia(Sprite.ARRIBA,
           new string[] { "assets\\personajes/up_soldier_1.png"
            , "assets\\personajes/up_soldier_2.png",
                "assets\\personajes/up_soldier_3.png" });
        personaje.CargarSecuencia(Sprite.ABAJO,
           new string[] { "assets\\personajes/down_soldier_1.png"
            , "assets\\personajes/down_soldier_2.png",
                "assets\\personajes/down_soldier_3.png" });

    }

    private static void ComprobarEstadoDelJuego()
    {
        for (int i = 0; i < DatosGlobales.cantidadItems; i++)
        {
            if (items[i].ColisionaCon(personaje))
            {
                items[i].SetActivo(false);
            }
        }
        for (int i = 0; i < DatosGlobales.CANTIDADZONAS; i++)
        {
            if (zonas[i].ColisionaCon(personaje))
            {
                zonas[i].SetActivo(false);
                DatosGlobales.SONIDOFONDO.Interrumpir();
                Thread.Sleep(100);
                DatosGlobales.SONIDOCOMBATE.ReproducirFondo();
                Combate combateACargar = new Combate((DatosGlobales.TIPOCOMBATE)
                    Enum.Parse(typeof(DatosGlobales.TIPOCOMBATE),i.ToString()));
                combateACargar.Start();
                
            }
        }
    }
    private static void PausarHastaFinDeFotograma()
    {
        Hardware.Pausa(20);
    }

    private static bool EsPosibleMoverA(
        int xIni, int yIni, int xFin, int yFin)
    {
        for (int fila = 0; fila < DatosGlobales.MAPA.Length; fila++)
        {
            for (int columna = 0; columna < DatosGlobales.MAPA[0].Length; columna++)
            {
                if (paredes[fila, columna] != null)
                {
                    if (paredes[fila, columna].ColisionaCon(
                            xIni, yIni, xFin, yFin))
                        return false;
                }
            }
        }
        return true;
    }
    public static void TerminarPartida()
    {
        partidaTerminada = true;
    }
        
}
