using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBg : MonoBehaviour

{
     float speed = 3f;

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
        if(transform.position.y <= -12){
            Reposition();
            Debug.Log("RepositionBG");
        }
    }
 

public void Reposition(){
    Vector2 position = transform.position;

    transform.position = new Vector2(0f,11f);


    }
}





