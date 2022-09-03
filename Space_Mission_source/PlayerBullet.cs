using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
   public MainScript MS;
   public EnemyControl EC;
   public EnemyAimControl EAC;
   public MeteorControl MC;
    // Start is called before the first frame update
    void Start()
    {
       MS = MainScript.GetInstance();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + MS.BulletSpeed * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        if(transform.position.y > max.y){
            Destroy(gameObject);
        }
    }
     public void OnCollisionEnter2D(Collision2D col)
    {
        
        
        if (col.gameObject.tag == "Enemy")
        {
           Destroy(col.gameObject);
           Destroy(gameObject);
           
           
           EC = col.gameObject.GetComponent<EnemyControl>();
           if(EC.isDead == false){
               MS.KillEnemy();
           }
           
           EC.isDead = true;   
        }

        if (col.gameObject.tag == "EnemyAim")
        {
           Destroy(col.gameObject);
           Destroy(gameObject);
           
           
           EAC = col.gameObject.GetComponent<EnemyAimControl>();
           if(EAC.isDead == false){
               MS.KillEnemy();
           }
           
           EAC.isDead = true;   
        }

        if (col.gameObject.tag == "Meteor")
        {
           Destroy(col.gameObject);
          
           
           MC = col.gameObject.GetComponent<MeteorControl>();
           if(MC.isDead == false){
               MS.DestroyMeteor();
           }

           MC.isDead = true;
        }

        if(col.gameObject.tag == "EnemyBullet"){
            Destroy(col.gameObject);
        }
    }
}
