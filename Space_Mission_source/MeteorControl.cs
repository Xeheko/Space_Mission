using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControl : MonoBehaviour
{
    float speed;
    float speedMin = 1f;
    float speedMax = 10f;
    float dropVector;
     float dropVectorMin = -1;
     float dropVectorMax = 1;
     public bool isDead = false;

     public MainScript MS;
    
   
    // Start is called before the first frame update
    void Start()
    {
        MS = MainScript.GetInstance();
        dropVector = Random.Range (dropVectorMax , dropVectorMin);
        speed = Random.Range(speedMax , speedMin);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x - speed * Time.deltaTime * dropVector , position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        Vector3 V3 = col.gameObject.transform.position;
        
      
        if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            MS.MeteorExplosionEffect(V3);    
        }
         if(col.gameObject.tag == "Meteor"){
            Destroy(gameObject);
            Destroy(col.gameObject);
            MS.MeteorExplosionEffect(V3); 
        }
        if(col.gameObject.tag == "DamageBorder"){
            Destroy(gameObject);
            
        }
        if(col.gameObject.tag == "Player"){
            Destroy(gameObject);
            MS.MeteorExplosionEffect(V3); 
        }
        if(col.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            MS.MeteorExplosionEffect(V3); 
        }
        if(col.gameObject.tag == "EnemyAim"){
            Destroy(gameObject);
            MS.MeteorExplosionEffect(V3); 
        }
        if(col.gameObject.tag == "EnemyBullet"){
            Destroy(gameObject);
            Destroy(col.gameObject);
            MS.MeteorExplosionEffect(V3);
        }        
        if(col.gameObject.tag == "EnemyAimBullet"){
            Destroy(gameObject);
            Destroy(col.gameObject);
            MS.MeteorExplosionEffect(V3);
        }
    }
}
