using UnityEngine;

public class OnBlackScreen : AutoMonobehaviour
{
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected double key = -1;

    protected override void Awake()
    {
        base.Awake();
        this.sprite = GetComponent<SpriteRenderer>();
        Invoke("Off", 2f);
    }
    protected virtual void Enable()
    {
        Invoke("Off", 2f);
    }

    protected virtual void Off()
    {
        this.gameObject.SetActive(false);
    }

    protected virtual void FixedUpdate()
    {
        if (this.sprite.color.r == 255 || this.sprite.color.r == 0) key = key * (-0.05);
        this.sprite.color = new Color(0, 0, 0, (byte)((int)this.sprite.color.r + key));
    }
}
