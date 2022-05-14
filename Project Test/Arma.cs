
class Arma
{
    private string nombreArma;
    private DatosGlobales.EFECTO efecto;
    private Skills skill;
    private Estadisticas stats;
    public Arma (string nombreArma, DatosGlobales.EFECTO efecto, Skills skill,
        Estadisticas stats)
    {
        this.nombreArma = nombreArma;
        this.efecto = efecto;
        this.skill = skill;
        this.stats = stats;
    }

    public string NombreArma
    {
        get { return nombreArma; }
        set { nombreArma = value;}
    }
    public DatosGlobales.EFECTO Efecto
    {
        get { return efecto; }
        set { efecto = value; }
    }
    public Skills Skills
    {
        get { return skill; }
        set { skill = value; }
    }
    public Estadisticas Stats
    {
        get { return stats; }
        set { stats = value; }
    }
}

