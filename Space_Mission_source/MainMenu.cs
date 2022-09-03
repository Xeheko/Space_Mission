using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public MainScript MS;

    // Start is called before the first frame update
    void Start()
    {
        MS = MainScript.GetInstance();     
        MS.Load();
        MS.LoadGameObject();
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
