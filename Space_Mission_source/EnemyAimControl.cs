using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimControl : MonoBehaviour
{
    float speed;
    float speedMin = 5f;
    float speedMax = 5f;
    double dropVector;
     double dropVectorMin = 0;
     double dropVectorMax = 0;
    public bool isDead = false;

    private Transform target;
    public Transform weaponMuzzle;
    public GameObject bullet; // prefab
    public float fireRate; // firerate
    public float shootingPower = 0.2f; // sila
     private float shootingTime;
 

         /*   shootingTime = Time.time + fireRate; // firerate
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); // position = muzzle
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity); //create bullet
            Vector2 direction = myPos - (Vector2)target.position; // smer
            projectile.GetComponent<Rigidbody2D>().velocity = direction * shootingPower; //shoot the bullet
    */
    
public MainScript MS;
   
    // Start is called before the first frame update
    void Start()
    {
        MS = MainScript.GetInstance();
        dropVector = Random.Range ((float)dropVectorMax , (float)dropVectorMin);
        speed = Random.Range(speedMax , speedMin);

        target = GameObject.FindWithTag("Player").transform;

        Fire();
    

    }

    // Update is called once per frame
    void Update()
    {
        

    Vector2 position = transform.position;

        position = new Vector2(position.x - speed * Time.deltaTime * (float)dropVector , position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    
    
    }

        private void Fire()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate; // firerate
            Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); // position = muzzle
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity); //create bullet
            Vector2 direction = myPos - (Vector2)target.position; // smer
            projectile.GetComponent<Rigidbody2D>().velocity = direction * shootingPower / 5; //shoot the bullet
        }
    } 



    public void OnCollisionEnter2D(Collision2D col){
        Vector3 V3 = col.transform.position;

        
        



         if(col.gameObject.tag == "DamageBorder")
        {
            Destroy(gameObject);
            MS.GetDamage();
        }
        if(col.gameObject.tag == "Meteor"){
            Destroy(gameObject);
            Destroy(col.gameObject);
            MS.EnemyExplosionEffect(V3);            
        }
        if(col.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            Destroy(col.gameObject);
            MS.EnemyExplosionEffect(V3);
        }
        if(col.gameObject.tag == "Player"){
            Destroy(gameObject);
            MS.EnemyExplosionEffect(V3);
        }
        if(col.gameObject.tag == "Bullet"){
            Destroy(gameObject);
            MS.EnemyExplosionEffect(V3);
        }

        
    }
    
}
