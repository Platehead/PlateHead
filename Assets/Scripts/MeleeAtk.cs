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
    
    public void Attack()
    {
        StartCoroutine(AttackExcute());
    }

    IEnumerator AttackExcute()
    {
        var MousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        var Melee = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Melee.transform.parent = transform;
        Melee.GetComponent<BoxCollider>().isTrigger = true;
        Melee.transform.localScale = new Vector3(0.74f, 0.185f, 1);
        Melee.name = "melee_Cube";

        int Flip = (MousePos.x < Screen.width / 2) ? -1 : 1;
        Debug.Log(Flip);
        Melee.transform.localPosition = new Vector3(0.77f * Flip, -0.2f, 0);

        yield return new WaitForSeconds(Duration);

        Destroy(Melee);

        yield return new WaitForSeconds(0.5f);


        yield return null;
    }
}
