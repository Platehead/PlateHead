using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAtk : MonoBehaviour, IAttackable {

    public GameObject bulletObj;
    public Transform gun;

    public void Attack()
    {
        var bullet = Instantiate(bulletObj);
        bullet.SetActive(true);
        bullet.transform.position = gun.position;
    }
}
