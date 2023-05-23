using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedReceiver : DamagedReceiver
{
    [SerializeField] protected EnemyController controller;
    [SerializeField] protected bool stop = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyController();
        this.health = this.healthMax;
    }

    protected virtual void LoadEnemyController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load Enemy Controller", gameObject);
    }

    public override void Deduct(int deduct)
    {
        this.controller.HealthBar.ChangeHealthBar((float) Mathf.Max(0, this.health - deduct) / this.healthMax);
        this.controller.HealthBar.transform.parent.gameObject.SetActive(true);
        base.Deduct(deduct);
        SpriteRenderer render = this.controller.Model.GetComponent<SpriteRenderer>();
        
        if (this.stop == false)
        {
            render.color = new Color32(221, 83, 11, 255);
            Invoke("ResetColor", 0.05f);
        }
        Invoke("DisappearHealthbar", 1f);
    }

    protected virtual void ResetColor()
    {
        SpriteRenderer render = this.controller.Model.GetComponent<SpriteRenderer>();
        render.color = new Color32(255, 255, 255, 255);
    }

    protected virtual void DisappearHealthbar()
    {
        this.controller.HealthBar.transform.parent.gameObject.SetActive(false);
    }

    protected override void OnDead()
    {
        base.OnDead();
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    public virtual void StopMoving(float time)
    {
        this.stop = true;
        this.controller.Movement.gameObject.SetActive(false);
        this.controller.Model.GetComponent<Animator>().enabled = false;
        this.controller.Model.GetComponent<SpriteRenderer>().color = new Color32(34, 84, 176, 255);
        StartCoroutine(this.ContinueMoving(time));
    } 

    protected IEnumerator ContinueMoving(float time)
    {
        yield return new WaitForSeconds(time);
        this.stop = false;
        this.controller.Movement.gameObject.SetActive(true);
        this.controller.Model.GetComponent<Animator>().enabled = true;
        this.controller.Model.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }
}
