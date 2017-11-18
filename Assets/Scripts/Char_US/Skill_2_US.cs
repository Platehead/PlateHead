using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2_US : MonoBehaviour, IAttackable
{
    public Transform Bomb;
    public float Speed;
    public ParticleSystem Eff;

	public void Attack()
    {
        StartCoroutine(AttackExecute());
    }

    IEnumerator AttackExecute()
    {
        var bomb = Instantiate(Bomb);
        bomb.position = transform.position;
        bomb.gameObject.AddComponent<Bomb_Move_US>();
        bomb.gameObject.GetComponent<Bomb_Move_US>().Speed = Speed;
        bomb.gameObject.GetComponent<Bomb_Move_US>().Eff = Eff;

        yield return null;
    }
}
