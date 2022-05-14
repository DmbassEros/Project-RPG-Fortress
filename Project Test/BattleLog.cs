class BattleLog
{
    private string texto;
    private DatosGlobales.COLOR color;

    public BattleLog(string texto, DatosGlobales.COLOR color)
    {
        this.texto = texto;
        this.color = color;
    }
    public string Texto
    { get { return texto; } }
    public DatosGlobales.COLOR Color
        { get { return color; } }
}
