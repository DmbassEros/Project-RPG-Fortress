using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Estadisticas
{
    protected int dmg;
    protected int def;
    protected int speed;
    protected int precision;
    protected int critChance;


    public Estadisticas(int dmg, int def, int speed,  int precision,
        int critChance )
    {
        this.dmg = dmg;
        this.def = def;
        this.speed = speed;
        this.precision = precision;
        this.critChance = critChance;
    }
    public int Dmg
    {
        get { return dmg; }
        set { dmg = value; }
    }
    public int Def
    {
        get { return def; }
        set { def = value; }
    }
    private int Speed
    {
        get { return Speed; }
        set { speed = value; }
    }
    public int Precision
    {
        get { return precision; }
        set { precision = value; }
    }
    public int CritChance
    {
        get { return critChance; }
        set { critChance = value; }
    }
}
