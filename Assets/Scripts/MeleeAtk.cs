using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtk : MonoBehaviour, IAttackable {
    /// <summary>
    /// 근접 공격의 데미지입니다.
    /// </summary>
    public float Damage = 20f;
    /// <summary>
    /// 근접 공격이 지속되는 시간입니다.
    /// </summary>
    public float Duration = 0.075f;

	void Start ()
    {
        
	}
	
    public void Attack()
    {
        StartCoroutine(AttackExcute());
    }

    IEnumerator AttackExcute()
    {
        
            var Melee = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Melee.transform.parent = transform;
            Melee.GetComponent<BoxCollider>().isTrigger = true;
            Melee.transform.localScale = new Vector3(0.74f, 0.185f, 1);
            Melee.name = "melee_Cube";
            Melee.transform.localPosition = new Vector3(0.77f, -0.2f, 0);

            yield return new WaitForSeconds(0.075f);

            Destroy(Melee);

            yield return new WaitForSeconds(0.5f);


            yield return null;
    }
}
