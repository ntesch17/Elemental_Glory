using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayAttack : MonoBehaviour {
    public Transform[] points = new Transform[3];
    public Transform[] secondPhasePoints = new Transform[2];
    public Transform bossCenter;
    public GameObject bossProjectile;
    public float projectileSpeed;
    bool secondPhase = false;
	// Use this for initialization
	void Awake () {
       //startAttacks(5);
       // secondPhase = true;
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void startAttacks(float duration)
    {
        StartCoroutine(SeriesOfAttacks(duration));
    }

    IEnumerator SeriesOfAttacks(float duration)
    {
        float timeInbetweenAttacks = .3f;
        for(int i = 0; i<=(duration/timeInbetweenAttacks);i++)
        {
        BossFireAttack();
        yield return new WaitForSecondsRealtime(timeInbetweenAttacks);
        }
        
    }
    void BossFireAttack()
    {

      
      
        if(!secondPhase){
        for (int i = 0; i <= points.Length - 1; i++)
        {
            var pos = bossCenter.transform.position;
            

            var bossAttack = Instantiate(bossProjectile, pos, new Quaternion(0, 0, 0, 0));
            var direction = points[i].transform.position - bossAttack.transform.position;
            direction.Normalize();

            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bossAttack.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            var rb = bossAttack.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;

          
            
           
        }
        }
        else
        {
            Transform[] allpoints = new Transform[]{ points[0], points[1], points[2], secondPhasePoints[0], secondPhasePoints[1] };
            for (int i = 0; i <= allpoints.Length - 1; i++)
            {
                var pos = bossCenter.transform.position;


                var bossAttack = Instantiate(bossProjectile, pos, new Quaternion(0, 0, 0, 0));
                var direction = allpoints[i].transform.position - bossAttack.transform.position;
                direction.Normalize();

                float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                bossAttack.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

                var rb = bossAttack.GetComponent<Rigidbody2D>();
                rb.velocity = direction * projectileSpeed;




            }
        }
       
      
    }
}
