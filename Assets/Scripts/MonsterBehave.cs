using UnityEngine;
using System.Collections;

public class MonsterBehave : MonoBehaviour {
    public Transform target;

    NavMeshAgent nma;
    Attributes attri;

    void Start() {
        nma = GetComponent<NavMeshAgent>();
        attri = GetComponent<Attributes>();
        StartCoroutine("WaitATick");
        nma.stoppingDistance = attri.range;

    }

    IEnumerator WaitATick()
    {
        Debug.Log("Starting zhe gaime");
        yield return new WaitForSeconds(1);
        StartCoroutine("Hunting");
        StartCoroutine("Hurting");
        

    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    IEnumerator Hunting() {
        
        while (true)
        {
            if (target == null && GameObject.FindGameObjectsWithTag("Hero").Length>0)
            {
               
                target = GameObject.FindGameObjectWithTag("Hero").transform;
                nma.destination = target.position;
            }
            yield return new WaitForSeconds(.1f);

        }
    }

    IEnumerator Hurting() {
        float attackDelay = attri.attackdelay;
        while (true)
        {
           
            attackDelay -= Time.deltaTime;
            if (attackDelay <= 0 && Vector3.Distance(transform.position, target.position) > attri.range && target != null) {

                    attackDelay = attri.attackdelay;
                    target.gameObject.SendMessage("TakeDamage", attri.damage);
                    if (GameObject.FindGameObjectsWithTag("Hero").Length > 0)
                        target = GameObject.FindGameObjectWithTag("Hero").transform;
                    


                
            }
            else if (attackDelay <= 0)
            {
                attackDelay = 0;
            }
            yield return null;


        }
    }



    void Update () {
	
	}
}
