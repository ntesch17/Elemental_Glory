using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnProjectile : MonoBehaviour {
    public List<GameObject> targets = new List<GameObject>();
    public GameObject lookAtTarget,dagger;
    public Vector2 ProjectileSpeed = new Vector2(10, 0);
    public float shootingCooldown;
    bool readyToShoot;
    // Use this for initialization
    void Start () {
		readyToShoot = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (targets.Count > 0)
        {
            DoubleCheckArray();
            lookAtTarget = compareDistances();
            if(readyToShoot)
            StartCoroutine(ShootTarget());
        }
        if(targets.Count == 0)
        {
            //DoubleCheckArray();
            lookAtTarget = null;
        }
        if (lookAtTarget != null)
        {
            Vector3 diff =lookAtTarget.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        this.GetComponentInChildren<MeshRenderer>().enabled = readyToShoot;
        this.GetComponent<MeshRenderer>().enabled = readyToShoot;
    }
    IEnumerator ShootTarget()
    {
        readyToShoot = false;
       
        var disDagger = Instantiate(dagger, this.gameObject.transform.position, this.gameObject.transform.rotation);
        var rb2d = disDagger.GetComponent<Rigidbody2D>();
        Vector3 diff = lookAtTarget.transform.position - disDagger.transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        disDagger.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        rb2d.velocity = diff * 10;

        yield return new WaitForSecondsRealtime(shootingCooldown);
        readyToShoot = true;
    }

    GameObject compareDistances()
    {
        GameObject closestTarget = null;
         if (targets.Count > 0)
        {
        closestTarget = targets[0];
        float distance = Vector2.Distance(this.transform.position,targets[0].transform.position);
       
            if (targets.Count>1){
        for(int i = 0; i<=targets.Count-1; i++){
            float newDist = Vector2.Distance(this.transform.position, targets[i].transform.position);
                if (newDist<distance)
                {
                    distance = newDist;
                    closestTarget = targets[i];
                }
        }
    }
        }

        

        return closestTarget;

    }
    void DoubleCheckArray()
    {
        for (int i = 0; i <= targets.Count - 1; i++)
        {
            if(targets[i]==null)
                targets.RemoveAt(i);


        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")|| collision.CompareTag("Boss"))
        {
            if(!targets.Contains(collision.gameObject))
            targets.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            targets.Remove(collision.gameObject);
        }
    }


}
