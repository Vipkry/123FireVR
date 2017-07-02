using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

    public bool onAttackPosition;
    public float attackDelay = 3.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine(doAttack());
	}

    private void FixedUpdate()
    {
        onAttackPosition = GetComponent<WaypointAgent>().onAttackPosition;
    }


    private IEnumerator doAttack()
    {
        while (true) {
            yield return new WaitForSeconds(attackDelay);
            if (onAttackPosition)
            {
                GetComponent<WaypointAgent>().m_waypointManager.GetComponent<SimpleSpawner>().baseLife--;
            }
        }

        //TODO: Botar animação do inimigo batendo
    }

}
