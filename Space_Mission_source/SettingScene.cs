using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingScene : MonoBehaviour
{
   public MainScript MS;

    // Start is called before the first frame update
    void Start()
    {
        MS = MainScript.GetInstance();     
        MS.LoadGameObject();
        MS.CheckResolution();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
