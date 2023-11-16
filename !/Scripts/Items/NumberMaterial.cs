[System.Serializable]
public class NumberMaterial
{
    public string nameMaterial = "none";
    public int numberMaterial = 0;

    public NumberMaterial(string _name, int _number) =>
        (nameMaterial, numberMaterial)  = (_name, _number);

    public void SetName(string _name) => nameMaterial = _name;

    public void SetNumber(int _number) => numberMaterial = _number;
}
