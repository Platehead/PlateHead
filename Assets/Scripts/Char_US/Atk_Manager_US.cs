using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_Manager_US : MonoBehaviour
{
    IAttackable Basic;
    IAttackable Skill_1;
    IAttackable Skill_2;
    HpManager hpManager;

    private void Start()
    {
        Basic = GetComponent<Basic_Atk_US>();
        Skill_2 = GetComponent<Skill_2_US>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Basic.Attack();
        if (Input.GetKeyDown(KeyCode.Mouse1))
            Skill_2.Attack();
    }

    void GetDamage(float damage)
    {
        hpManager.Hp -= damage;
    }
}