using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    
    public MainScript MS;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        MS = MainScript.GetInstance();     
        MS.LoadGameObject();
        MS.PauseMenuCanvasGO = GameObject.FindWithTag("PauseMenu");
        MS.PauseSettingsCanvasGO = GameObject.FindWithTag("PauseSettings");
        MS.GameOverCanvasGO = GameObject.FindWithTag("GameOver");
        MS.PauseMenuOFF();
        MS.PauseSettingsCanvasGO.SetActive(false);
        MS.GameOverCanvasGO.SetActive(false);
        MS.ReadyToShoot = true;
        MS.CurrentPlayerHP = MS.MaxPlayerHP;
        MS.Shield = MS.MaxPlayerShield;
        MS.KillCount = MS.MinKillCount;
        MS.LoadPlayer();
    }
    
}
