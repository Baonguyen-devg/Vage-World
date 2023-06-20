using UnityEngine;

public class Portal : AutoMonobehaviour
{
    [SerializeField] protected Transform goal;


    public virtual void ChangeGoal(Transform _goal)
    {
        this.goal = _goal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player") return;

        collision.transform.position = goal.position + new Vector3(2, 0, 0);
    }
}
