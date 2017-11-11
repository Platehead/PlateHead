using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
    public RectTransform hpGauge;
    float hpGaugeLength;
    public float maxHP;
    public float hp;
	// Use this for initialization
	void Start () {
        hpGaugeLength = hpGauge.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        hpGauge.localScale = new Vector2(hpGaugeLength * hp / maxHP, hpGauge.localScale.y);
	}
}
