using UnityEngine;

public class PlayerDamagedReceiver : DamagedReceiver
{
    [SerializeField] protected PlayerController controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<PlayerController>();
        Debug.Log(transform.name + ": Load Player Controller", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.controller.Model.GetComponent<Animator>().SetTrigger("Die");
        UIController.Instance.LoseGame();
    }
}
