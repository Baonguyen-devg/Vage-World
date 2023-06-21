[System.Serializable]
public class NumberMaterial
{
    public string nameMaterial = "none";
    public int numberMaterial = 0;

    public NumberMaterial(string _name, int _number) =>
        (this.nameMaterial, this.numberMaterial)  = (_name, _number);

    public void SetName(string _name) => this.nameMaterial = _name;

    public void SetNumber(int _number) => this.numberMaterial = _number;
}
