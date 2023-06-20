using UnityEngine;

public class BlackScreen : AutoMonobehaviour
{
    [SerializeField] protected double rateTime;
    [SerializeField] protected double nextTime;

    protected virtual void Update()
    {
        if (Time.time < this.nextTime) return;
        this.nextTime = Time.time + this.rateTime;

        transform.Find("On").gameObject.SetActive(true);
        Invoke("Off", 2.2f);
    }

    protected virtual void Off()
    {
        transform.Find("On").gameObject.SetActive(false);
    }
}
