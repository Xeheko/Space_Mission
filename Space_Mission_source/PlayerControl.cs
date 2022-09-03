using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
public GameObject PlayerBulletGO;
public GameObject bulletPosition01;
public GameObject bulletPosition02;
public GameObject bulletPosition03;
public GameObject bulletPosition04;



public MainScript MS;

    // Start is called before the first frame update
    void Start()
    {
        MS = MainScript.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown("space") && MS.ReadyToShoot){

          MainScript.PlaySound("FireSound");


          GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO);
          bullet01.transform.position = bulletPosition01.transform.position;
        
        MS.ReadyToShoot = false; 
        
        StartCoroutine(Reload());

          GameObject bullet02 = (GameObject)Instantiate (PlayerBulletGO);
          bullet02.transform.position = bulletPosition02.transform.position;

          GameObject bullet03 = (GameObject)Instantiate (PlayerBulletGO);
          bullet03.transform.position = bulletPosition03.transform.position;

          GameObject bullet04 = (GameObject)Instantiate (PlayerBulletGO);
          bullet04.transform.position = bulletPosition04.transform.position;
      }
        float x = Input.GetAxisRaw ("Horizontal");
        float y = Input.GetAxisRaw ("Vertical");

        Vector2 direction = new Vector2 (x, y).normalized;

        Move(direction);
    }
    void Move(Vector2 direction){
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        max.x = max.x - 0.5f;
        min.x = min.x + 0.5f;

        max.y = max.y - 0.5f;
        min.y = min.y + 0.5f;

        Vector2 pos = transform.position;

        pos += direction * MS.PlayerSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
        pos.y = Mathf.Clamp (pos.y, min.y, max.y);

        transform.position = pos;
    }
    
    public void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.tag == "Enemy")
        {
           Destroy(col.gameObject);
          
           MS.KillEnemy();
           MS.GetDamage();
           MS.KillCountBonus();
           
        }

        if (col.gameObject.tag == "Meteor")
        {
           Destroy(col.gameObject);
          
           
           MS.GetDamage();
           
        }

        if(col.gameObject.tag == "EnemyBullet"){
            
            Destroy(col.gameObject);
            MS.GetDamage();
        
        }
    }

    
    private IEnumerator Reload()
    {
        
   
            yield return new WaitForSeconds(MS.ReloadTime);
            MS.ReadyToShoot = true;
           
       
    }
  
}
