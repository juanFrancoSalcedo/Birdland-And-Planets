

[System.Serializable]
public class Cannon:ICopy<Cannon>
{
    public float attack;
    public float x;
    public float y;
    public float z;

    public Cannon Copy()
    {
        return (Cannon)this.MemberwiseClone();
    }
}
