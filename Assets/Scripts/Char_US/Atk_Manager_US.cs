using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_Manager_US : MonoBehaviour
{
    IAttackable melee;
    IAttackable ranged;
    IAttackable skill_1;
    IAttackable skill_2;
    HpManager hpManager;

    private void Start()
    {
        melee = GetComponent<MeleeAtk>();
        ranged = GetComponent<Basic_Atk_US>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            melee.Attack();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            ranged.Attack();
    }

    void GetDamage(float damage)
    {
        hpManager.Hp -= damage;
    }
}