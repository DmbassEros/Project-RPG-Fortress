using System.Collections.Generic;
using static DatosGlobales;
using System.Threading;

class Combate
{
    private Imagen fondo;
    static int xPersonaje, yPersonaje, xEnemigo;
    static bool combateTerminado;
    static bool turnoBot;
    static Personaje estadoPersonaje, estadoEnemigo;
    private Queue<BattleLog> colaBattleLog = new Queue<BattleLog>();


    public Combate(TIPOCOMBATE TIPO)
    {
        DatosGlobales.LETRA_COMBATE = new Fuente("assets\\fuentes/Top Secret.ttf", 22);
        DatosGlobales.LETRA_ENEMIGO = new Fuente("assets\\fuentes/Top Secret.ttf", 22);
        fondo = new Imagen("assets\\escenas/" + TIPO + ".png");
        estadoPersonaje = new Personaje("Soldier", 200,
          new Estadisticas(30, 20, 5, 10, 20), null, "assets\\personajes/soldier.png");
        estadoEnemigo = new Personaje("RobotSolly", 250,
            new Estadisticas(20, 10, 3, 10, 20), null, "assets\\enemigos/enemigo_soldier.png");
        estadoPersonaje.SetAnchoAlto(DatosGlobales.ANCHOPERSONAJE_COMBAT,
            DatosGlobales.ALTOPERSONAJE_COMBAT);
        estadoEnemigo.SetAnchoAlto(DatosGlobales.ANCHOPERSONAJE_COMBAT,
            DatosGlobales.ALTOPERSONAJE_COMBAT);
        xPersonaje = DatosGlobales.POSXPERSONAJE_COMBAT;
        yPersonaje = DatosGlobales.POSYPERSONAJE_COMBAT;
        xEnemigo = DatosGlobales.POSXENEMIGO_COMBAT;

        combateTerminado = false;
        turnoBot = false;
    }

    public void Start()
    {
        combateTerminado = false;
        BucleCombate();
    }
    void BucleCombate()
    {
        while (!combateTerminado)
        {
            DibujarPantalla();
            ComprobarEntradaUsuario();
            CombateIA();
            ComprobarCombate();
            //AnimarElementos();
            //ComprobarEstadoDelJuego();
            PausarHastaFinDeFotograma();
        }
        ActualizarMusica();
    }
    void ActualizarMusica()
    {
        Thread.Sleep(100);
        SONIDOFONDO.ReproducirFondo();
    }
    private void ActualizarBattleLog(BattleLog texto)
    {
        if (colaBattleLog.Count > 6)
        {
            colaBattleLog.Dequeue();
        }
        colaBattleLog.Enqueue(texto);
    }
    private void CombateIA()
    {
        if (turnoBot)
        {
            estadoPersonaje.Salud -= estadoEnemigo.BaseStats.Dmg;
            ActualizarBattleLog(new BattleLog("Robot te ha hecho " +
                estadoPersonaje.BaseStats.Dmg + " daño",COLOR.AZUL));
            turnoBot = false;
        }
    }
    private void ComprobarCombate()
    {
        if(estadoPersonaje.Salud <= 0)
        {
            combateTerminado = true;
        }
    }
    private void ComprobarEntradaUsuario()
    {
        if (Hardware.TeclaPulsada(Hardware.TECLA_1))
        {
            Thread.Sleep(250);
            estadoEnemigo.Salud -= estadoPersonaje.BaseStats.Dmg;
            ActualizarBattleLog(new BattleLog("Jugador ha hecho " +
                (estadoPersonaje.BaseStats.Dmg) + " daño",COLOR.ROJO));
            turnoBot = true;
        }
        if (Hardware.TeclaPulsada(Hardware.TECLA_3))
        {
            turnoBot = true;
        }
        if (Hardware.TeclaPulsada(Hardware.TECLA_4))
        {
            int random =  DatosGlobales.GENERADOR.Next(0, 100);
            if (random > 80)
            {
                turnoBot = true;
            }
            else
            {
                combateTerminado = true;
            }
        } 
    }

    private void PausarHastaFinDeFotograma()
    {
        Hardware.Pausa(20);
    }
    private void CargarMenu()
    {
        Hardware.EscribirTextoOculta("1. ATACAR",
            100, 50, 255, 158, 0, DatosGlobales.LETRA_MAIN);
        Hardware.EscribirTextoOculta("2. HABILIDADES",
            230, 50, 255, 158, 0, DatosGlobales.LETRA_MAIN);
        Hardware.EscribirTextoOculta("3. PASAR TURNO",
            435, 50, 255, 158, 0, DatosGlobales.LETRA_MAIN);
        Hardware.EscribirTextoOculta("4. HUIR",
            650, 50, 255, 158, 0, DatosGlobales.LETRA_MAIN);
    }
    private void DibujarLog()
    {
        int i = 150;

        foreach (BattleLog bp in colaBattleLog)
        {
            if (bp.Color == COLOR.ROJO)
            {
                Hardware.EscribirTextoOculta(bp.Texto,
                    925, i, 229, 52, 8, DatosGlobales.LETRA_COMBATE);
                i -= 30;
            }
            else
            {
                Hardware.EscribirTextoOculta(bp.Texto,
                    925, i, 29, 108, 223, DatosGlobales.LETRA_COMBATE);
                i -= 30;
            }
        }
    }

    private void DibujarPantalla()
    {
        Hardware.BorrarPantallaOculta();
        fondo.Dibujar(0,0);
        estadoEnemigo.MoverA(xEnemigo, yPersonaje);
        estadoEnemigo.DibujarPersonaje();
        estadoPersonaje.MoverA(xPersonaje, yPersonaje);
        estadoPersonaje.DibujarPersonaje();
        CargarMenu();
        DibujarLog();
        Hardware.VisualizarOculta();

    }
}

