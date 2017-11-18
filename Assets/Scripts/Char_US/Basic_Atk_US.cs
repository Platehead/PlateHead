using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Atk_US : MonoBehaviour, IAttackable {

    public Transform Bullet;
    public float Speed;
    public float DelayOnShoots;

    public void Attack()
    {
        StartCoroutine(AttackExcute());
    }

    IEnumerator AttackExcute()
    {
        for (int i = 0; i < 3; i++)
        {
            var bul = Instantiate(Bullet);
            bul.position = transform.position;
            bul.gameObject.AddComponent<Bullet_Move_US>();
            bul.gameObject.GetComponent<Bullet_Move_US>().Speed = Speed;
            
            yield return new WaitForSeconds(DelayOnShoots);
        }

        yield return null;
    }
}
