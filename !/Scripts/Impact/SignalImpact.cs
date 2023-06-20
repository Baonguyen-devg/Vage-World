using UnityEngine;

public class SignalImpact : Impact
{
    [SerializeField] protected EnemyController controller;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadController();
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Controller", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name != "Main Camera") return;

        this.controller.Movement.gameObject.SetActive(true);
        this.controller.Model.GetComponent<Animator>().SetTrigger("Run");
    }
}
