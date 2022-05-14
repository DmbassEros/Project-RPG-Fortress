using System;
class Inventario
{
    private string item;
    private int money;

    public Inventario(string item, int money)
    {
        this.item = item;
        this.money = money;
    }

    public string Item
    {
        get { return item; }
        set { item = value; }
    }
    public int Money
    {
        get { return money; }
        set { money = value; }
    }

}
