using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : WaypointAgent
{

    public int attackDelay;

    protected override void WaypointMovementUpdate()
    {
    }

    public IEnumerator attack()
    {

        yield return new WaitForSecondsRealtime(attackDelay);

    }

}