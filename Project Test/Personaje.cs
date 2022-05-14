
using System.Collections.Generic;

class Personaje : Sprite
{
    private string nombre;
    private int salud;
    private Estadisticas baseStats;
    private List <Arma> armas;

    public Personaje(string nombre, int salud, Estadisticas baseStats,
        List<Arma> armas, string nombreImagen) : base ( nombreImagen)
    {
        this.nombre = nombre;
        this.salud = salud;
        this.baseStats = baseStats;
        this.armas = armas;
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    public int Salud
    {
        get { return salud; }
        set { salud = value; }
    }
    public Estadisticas BaseStats
    {
        get { return baseStats; }
        set { baseStats = value; }
    }
    public List <Arma> Armas
    {
        get { return armas; }
        set { armas = value; }
    }

    public void DibujarPersonaje()
    {
        Dibujar();
        Hardware.EscribirTextoOculta("Salud: "+salud,
           x, y+alto+10, 255, 255, 255, DatosGlobales.LETRA_MAIN);
    }
}
