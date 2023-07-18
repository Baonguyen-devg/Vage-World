using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    protected override bool CanDespawn()
    {
        return true;
    }
}
