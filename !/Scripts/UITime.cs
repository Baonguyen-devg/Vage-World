using UnityEngine;
using UnityEngine.UI;

public class UITime : AutoMonobehaviour
{
    protected virtual void Update() =>
        transform.GetComponent<Image>().fillAmount = 1 - Time.time / GameController.Instance.TimeAppearBoss;
}
