using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour {
    public float health, mxHealth, damage, level, xp, attackdelay, range, damagereduction, gold;


    void Start()
    {
        health = 10;
        mxHealth = health;
        damage = 2;
        level = 1;
        xp = 0;
        attackdelay = 1f;
        gold = 10;
        damagereduction = 0;
        range = Random.Range(1, 5);

    }

    public void TakeDamage(float damage)
    {

        health -= damage;
        
        if (health <= 0)
        {
            DestroyObject(gameObject);
        }

    }


   



    void Update () {
	
	}
}
