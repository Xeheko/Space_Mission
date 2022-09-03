using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimBullet : MonoBehaviour
{
 public float TimeLeft = 5;

    public EnemyControl EC;
    public MainScript MS;
    // Start is called before the first frame update
    void Start()
    {
        MS = MainScript.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }


    
    public void OnCollisionEnter2D(Collision2D col){
        Vector3 V3 = col.transform.position;

        if(col.gameObject.tag == "Meteor"){
            Destroy(gameObject);
            Destroy(col.gameObject);
            MS.EnemyExplosionEffect(V3);            
        }
        if(col.gameObject.tag == "Player"){
            Destroy(gameObject);
            MS.GetDamage();
            MS.EnemyExplosionEffect(V3);
        }
        if(col.gameObject.tag == "Bullet"){
            Destroy(gameObject);
            Destroy(col.gameObject);
            MS.EnemyExplosionEffect(V3);
        }
        if(col.gameObject.tag == "DamageBorder"){
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            Destroy(col.gameObject);
            MS.EnemyExplosionEffect(V3);
        }
    }
}
