using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Bot : MonoBehaviour {

    HpManager hp;

	void Start () {
        hp = new HpManager(100f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER!!!!!");
        if (collision.tag == "Melee")
        {
            hp.Hp -= collision.gameObject.GetComponent<MeleeAtk>().Damage;
            Debug.Log("OnTriggerEnter2D");
            Debug.Log(hp.Hp);
        }

        if (hp.Hp <= 0)
            Destroy(gameObject);
    }
}
