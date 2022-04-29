using System;
using System.Threading;
using Tao.Sdl;

class Program
{
    static bool terminado;
    static Sprite personaje;
    static Sprite[] items;
    static Sprite[] zonas;
    static int x, y;
    static Fuente tipoDeLetra;
    static Sprite[,] paredes;
    static Sprite[,] fondo;
    static int xMapa = 1, yMapa = 1 ;
    static int anchoTile = 30, altoTile = 30;
    static string texturaFondo;       

    static void Main(string[] args)
    {
        InicializarJuego();
        while (!terminado)
        {
            DibujarPantalla();
            ComprobarEntradaUsuario();
            AnimarElementos();
            ComprobarEntradaUsuario();
            ComprobarEstadoDelJuego();
            PausarHastaFinDeFotograma();
        }
    }
    private static void InicializarJuego()
    {
        Hardware.Inicializar(1280, 720, 24);
        personaje = new Sprite("assets\\personajes/down_soldier_2.png");
        personaje.SetAnchoAlto(DatosGlobales.AnchoPersonaje, DatosGlobales.AltoPersonaje);
        x = DatosGlobales.PosXPersonaje;
        y = DatosGlobales.PosYPersonaje;


        items = new Sprite[DatosGlobales.cantidadItems];
        for (int i = 0; i < DatosGlobales.cantidadItems; i++)
        {
            items[i] = new Sprite("assets\\items/ammo.png");
            items[i].MoverA(
                DatosGlobales.generador.Next(0, 650),
                 DatosGlobales.generador.Next(0, 300));
        items[i].SetAnchoAlto(DatosGlobales.AnchoyAltoItem, DatosGlobales.AnchoyAltoItem);
        }
        zonas = new Sprite[DatosGlobales.cantidadZonas];
        for (int i = 0; i < DatosGlobales.cantidadZonas; i++)
        {
            zonas[i] = new Sprite("assets\\estructura/zona" + DatosGlobales.generador.Next(1, 4) + ".png");
            zonas[i].MoverA(
                DatosGlobales.generador.Next(250, 1100),
                 DatosGlobales.generador.Next(300, 450));
            zonas[i].SetAnchoAlto(DatosGlobales.AnchoyAltoZona, DatosGlobales.AnchoyAltoZona);
        }
        terminado = false;
        tipoDeLetra = new Fuente("assets\\fuentes/tf2build.ttf", 24);
        
        paredes = new Sprite[DatosGlobales.Mapa.Length,
            DatosGlobales.Mapa[0].Length];
        for (int fila = 0; fila < DatosGlobales.Mapa.Length; fila++)
        {
            for (int columna = 0; columna < 
                DatosGlobales.Mapa[0].Length;columna++)
            {
                if (DatosGlobales.Mapa[fila][columna] == '#')
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
        fondo = new Sprite[DatosGlobales.Mapa.Length,
            DatosGlobales.Mapa[0].Length];
        for (int fila = 0; fila < DatosGlobales.Mapa.Length; fila++)
        {
            for (int columna = 0; columna <
                DatosGlobales.Mapa[0].Length; columna++)
            {
                texturaFondo = DatosGlobales.Mapa[fila][columna].ToString();
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
                if (DatosGlobales.Mapa[fila][columna] == '╗')
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
       
        
        for (int fila = 0; fila < DatosGlobales.Mapa.Length; fila++)
        {
            for (int columna = 0; columna <
                DatosGlobales.Mapa[0].Length; columna++)
            {
                if (paredes[fila,columna] != null)
                {
                    paredes[fila, columna].Dibujar();
                }
            }
        }
        for (int fila = 0; fila < DatosGlobales.Mapa.Length; fila++)
        {
            for (int columna = 0; columna <
                DatosGlobales.Mapa[0].Length; columna++)
            {
                if (fondo[fila, columna] != null)
                {
                    fondo[fila, columna].Dibujar();
                }
            }
        }
        for (int i = 0; i < DatosGlobales.cantidadZonas; i++)
        {
            zonas[i].Dibujar();
        }
        for (int i = 0; i < DatosGlobales.cantidadItems; i++)
        {
            items[i].Dibujar();
        }
        personaje.MoverA(x, y);
        personaje.Dibujar();
        Hardware.EscribirTextoOculta("Equipo " + DatosGlobales.Score,
            1100, 10, 255, 153, 51, tipoDeLetra);
        Hardware.VisualizarOculta();
    }
    private static void ComprobarEntradaUsuario()
    {
        // Movimientos
        // Izquierda
        if ((Hardware.TeclaPulsada(Hardware.TECLA_IZQ))
                && EsPosibleMoverA(x - DatosGlobales.velocidad, y,
                x + DatosGlobales.AnchoPersonaje - DatosGlobales.velocidad,
                y + DatosGlobales.AltoPersonaje))
            x -= DatosGlobales.velocidad;
        // Derecha
        if ((Hardware.TeclaPulsada(Hardware.TECLA_DER))
                && EsPosibleMoverA(x + DatosGlobales.velocidad, y,
                x + DatosGlobales.AnchoPersonaje + DatosGlobales.velocidad,
                y + DatosGlobales.AltoPersonaje))
            x += DatosGlobales.velocidad;
        // Arriba
        if ((Hardware.TeclaPulsada(Hardware.TECLA_ARR))
             && EsPosibleMoverA(x, y - DatosGlobales.velocidad,
             x + DatosGlobales.AnchoPersonaje,
             y + DatosGlobales.AltoPersonaje - DatosGlobales.velocidad))
            y -= DatosGlobales.velocidad;
        // Abajo
        if ((Hardware.TeclaPulsada(Hardware.TECLA_ABA))
                && EsPosibleMoverA(x, y + DatosGlobales.velocidad,
                x + DatosGlobales.AnchoPersonaje,
                y + DatosGlobales.AltoPersonaje + DatosGlobales.velocidad))
            y += DatosGlobales.velocidad;

        if (Hardware.TeclaPulsada(Hardware.TECLA_ESC))
            terminado = true;
    }
    private static void AnimarElementos()
    {
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
        for (int i = 0; i < DatosGlobales.cantidadZonas; i++)
        {
            if (zonas[i].ColisionaCon(personaje))
            {
                zonas[i].SetActivo(false);
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
        for (int fila = 0; fila < DatosGlobales.Mapa.Length; fila++)
        {
            for (int columna = 0; columna < DatosGlobales.Mapa[0].Length; columna++)
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
}
