using UnityEngine;
using System.Collections;

public class HeroBehave : MonoBehaviour {



    public Transform target;

    NavMeshAgent nma;
    Attributes attri;

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        attri = GetComponent<Attributes>();
        StartCoroutine("WaitATick");
        nma.stoppingDistance = attri.range;
      
    }

    IEnumerator WaitATick()
    {
      
        yield return new WaitForSeconds(1);
        StartCoroutine("Hunting");
        StartCoroutine("Hurting");
        StartCoroutine("Intelligence");


    }

    IEnumerator Intelligence() {

        while (true)
        {
            if (attri.health < attri.mxHealth/2)
            {
                StopAllCoroutines();
                StartCoroutine("Flee");
            }
            yield return new WaitForSeconds(1);
        }

    }

    IEnumerator Flee() {
        if (GameObject.FindGameObjectsWithTag("Hero").Length > 0)
        {
            target = GameObject.FindGameObjectWithTag("Hero").transform;
            nma.destination = target.position;
        }
        else {
            nma.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);

        }

        yield return new WaitForSeconds(5);
        StartCoroutine("WaitATick");

    }

    IEnumerator Hunting()
    {

        while (true)
        {
            if (target == null)
            {
            
                target = GameObject.FindGameObjectWithTag("Monster").transform;
                nma.destination = target.position;
            }
            else
            {
            

                    nma.destination = target.position;
                
            }
            yield return new WaitForSeconds(.1f);

        }
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    IEnumerator Hurting()
    {
        float attackDelay = attri.attackdelay;
        while (true)
        {
          
            

            attackDelay -= Time.deltaTime;
            if (attackDelay <= 0 && Vector3.Distance(transform.position, target.position) > attri.range && target != null)
            {
                    attackDelay = attri.attackdelay;
                    target.gameObject.SendMessage("TakeDamage", attri.damage);
                            }
            else if (attackDelay <= 0)
            {
                attackDelay = 0;
            }
            yield return null;


        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
