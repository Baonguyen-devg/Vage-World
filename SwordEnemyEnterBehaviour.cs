using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyEnterBehaviour : StateMachineBehaviour
{
    private const float default_Angle = 45;
    private const float default_Speed_Rotation = 1f;

    [SerializeField] private float speedRotation = default_Speed_Rotation;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.localRotation.z == default_Angle) return;
        float angleKey = (animator.transform.localRotation.z + this.speedRotation) % 360;

        Vector3 newAngle = new Vector3(0, 0, angleKey);
        animator.transform.localRotation = Quaternion.Euler(newAngle);
    }
}
