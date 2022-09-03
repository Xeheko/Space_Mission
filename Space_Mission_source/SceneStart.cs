using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneStart : MonoBehaviour
{
    public MainScript MS;

    // Start is called before the first frame update
    void Start()
    {
        MS = MainScript.GetInstance();     
        MS.LoadGameObject();
        Cursor.visible = true;
        MS.ShowShip();     
        MS.CheckResolution();
        MS.Load();

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
