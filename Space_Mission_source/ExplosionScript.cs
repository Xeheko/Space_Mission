using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

   
     float speed = -2f;

     float dropVector = 0;

    MainScript MS;
 
 void Start () {
     MS = MainScript.GetInstance();
     
 }

 void Update(){
        
        
        Vector2 position = transform.position;

        position = new Vector2(position.x - speed * Time.deltaTime * dropVector , position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        
    }

}
