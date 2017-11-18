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
        
        //마우스 위치에 따라서 공격의 방향 설정
        int Flip = (MousePos.x < Screen.width / 2) ? -1 : 1;
        Melee.transform.localPosition = new Vector3(0.095f * Flip, -0.03f, 0);
        
        Melee.transform.localScale = new Vector3(0.115f, 0.03f, 1);
        Melee.name = "melee_Cube";
        Destroy(Melee.GetComponent<BoxCollider>());

        yield return new WaitForSeconds(0.0001f);

        Melee.AddComponent<BoxCollider2D>();
        Melee.GetComponent<BoxCollider2D>().isTrigger = true;
        
        yield return new WaitForSeconds(Duration);

        Destroy(Melee);

        yield return new WaitForSeconds(0.5f);
        yield return null;
    }
}
