﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterExample : MonoBehaviour
{
    IAttackable attack1;
    IAttackable attack2;
    HpManager hpManager;

    private void Start()
    {
        attack1 = GetComponent<MeleeAtk>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            attack1.Attack();

        if (Input.GetKeyDown(KeyCode.X))
            attack2.Attack();
    }

    void GetDamage(float damage)
    {
        hpManager.Hp -= damage;
    }
}