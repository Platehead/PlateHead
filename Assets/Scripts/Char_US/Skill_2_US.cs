using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2_US : MonoBehaviour, IAttackable
{
    public Transform Bomb;

	public void Attack()
    {
        StartCoroutine(AttackExecute());
    }

    IEnumerator AttackExecute()
    {
        var bomb = Instantiate(Bomb);
        bomb.position = transform.position;

        yield return null;
    }
}
