using UnityEngine;
using System.Collections;

public class DamagePackage : MonoBehaviour {
    float damage;
    GameObject sender;
	// Use this for initialization
	void Start () {
	
	}

    public void SetDamage(float dam, GameObject sen) {
        damage = dam;
        sender = sen;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
