using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Audio;
using TMPro;



public class MainScript : MonoBehaviour
{
    static MainScript instance = null;

    public int ShowShipIndex = 1;

    public float ReloadTime = 0.5f;
    public float BulletSpeedEnemy = -15f;
    public float BulletSpeed = 15f;
    public float PlayerSpeed = 8f;
    public float KillCount = 0;
    public float HighScore;
    public float MinKillCount = 0;
    public float maxSpawnRateInSeconds = 10f;
    public float ExplosionSpeed = -3f;

    public bool PauseMenuCheck = false;
    public bool ReadyToShoot = true;

    public int MaxPlayerHP = 100;
    public int CurrentPlayerHP = 100;
    public int Shield = 30;
    public int MaxPlayerShield = 30;


    public double dropVector = 0;

    public TextMeshPro ScoreCounter;
    public TextMeshPro HealthBar;
    public TextMeshPro ShieldBar;
    public Text ShipSelectionText;
    public Text ShipStatSpeed;
    public Text ShipStatFireRate;
    public Text ShipStatHealth;
    public Text ShipStatShield;
    public Text HighScoreCounter;
    public Text CurrentScore;

    public GameObject MeteorExplosionPrefab;
    public GameObject EnemyExplosionPrefab;
    public GameObject FullScreenText = null;
    public GameObject WindowText = null;
    public GameObject PauseMenuCanvasGO = null;
    public GameObject PauseSettingsCanvasGO = null;
    public GameObject GameOverCanvasGO = null;
    public GameObject GameMusicGO;
    public GameObject MenuMusicGO;
    public GameObject characterS;
    public GameObject PlayerGO;
    
    public Slider SliderM;
    public Slider SliderS;

    public AudioSource AudioListenerMenu;
    public AudioSource AudioListenerGame;
    public AudioSource AudioListenerSound;

    public CharacterDatabase CD;

    public static AudioClip FireSound, BtnSound;
    static AudioSource AudioSrc;

    public AudioMixer MenuMusic;
    public AudioMixer GameMusic;
    public AudioMixer SoundMusic;

    public float musicVolume;
    public float soundVolume;






    public static void PlaySound (string clip){
        switch (clip){
            case "FireSound":
                AudioSrc.PlayOneShot (FireSound);
                break;
            case "BtnSound":
                AudioSrc.PlayOneShot (BtnSound);
                break;
        }
    }


    public void ChangeMusicVolume(float sliderValue){
            MenuMusic.SetFloat("MenuMusic", Mathf.Log10(sliderValue) * 20);
            GameMusic.SetFloat("MenuMusic", Mathf.Log10(sliderValue) * 20);
            musicVolume = sliderValue;
            Debug.Log(sliderValue);
            Save();
    }


    public void ChangeSoundVolume(float sliderValue){
            SoundMusic.SetFloat("SoundVolume", Mathf.Log10(sliderValue) * 20);
            soundVolume = sliderValue;
            Save();
    }



    public void Load(){

            soundVolume = PlayerPrefs.GetFloat("SoundVolume", 50);
            musicVolume = PlayerPrefs.GetFloat("MenuMusic", 50);

    }


    public void Save(){

        PlayerPrefs.SetFloat("MenuMusic", musicVolume);
        PlayerPrefs.SetFloat("MenuMusic", musicVolume);
  
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);

        Debug.Log("Save");
        
        PlayerPrefs.SetFloat("Highscore", HighScore);
    }


    //  public CharacterManager CM;

   void Awake()
    {
        KillCount = PlayerPrefs.GetFloat("Highscore", 0);
        HighScore = PlayerPrefs.GetFloat("Highscore", 0);


        Load();
        
        
        if (instance == null)
        {
            instance = this;
            
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    
    }
    public static MainScript GetInstance()
    {
        
        return instance;
    }

    public void KillEnemy(){
        
        KillCount ++;
    }




    
    public void GetDamage(){
        if(Shield <= 0){
            CurrentPlayerHP -=5;
            
        }else{
            Shield -=5;
          //  BulletSpeedBuff.SetActive(true);
        }
        Death();
        }
       
    


    public void Death(){
        if(CurrentPlayerHP <=0 ){
            Cursor.visible = true;
            GameOverCanvasGO.SetActive(true);
            Time.timeScale=0;


        if(PlayerPrefs.HasKey("Highscore")){
            if(KillCount > PlayerPrefs.GetFloat("Highscore")){
                HighScore = KillCount;
                PlayerPrefs.SetFloat("Highscore", HighScore);
                PlayerPrefs.Save();
            }
        }
            
        }
    }

    public void DestroyMeteor(){
        
        if(Shield ==30){
            
        }else{
            Shield +=5;
        }
    }



    public void KillCountBonus()
    {
       
         if(KillCount %10 == 0)
        {
            PlayerSpeed++;
        }
        if(KillCount %50 == 0)
        {
            ReloadTime -= 0.05f;
        }
        if(KillCount  %30 ==0)
        {
            maxSpawnRateInSeconds += 0.7f;
        }
    } 
   
    public void LoadGameObject()
   {
      
      GameObject PlayButton = GameObject.FindWithTag("MenuButtonPlay");
      GameObject ExitButton = GameObject.FindWithTag("MenuButtonExit");
      GameObject OptionsButton = GameObject.FindWithTag("MenuButtonOptions");
      GameObject BackButton = GameObject.FindWithTag("MenuButtonBack");
      GameObject ResumeButton = GameObject.FindWithTag("ResumeButton");
      GameObject FullScreenButton = GameObject.FindWithTag("MenuButtonFullScreen");
      GameObject ResolutionButton = GameObject.FindWithTag("MenuButtonResolution");
      GameObject ChangeShipButton = GameObject.FindWithTag("ShipSelection");
      GameObject NextSkinButton = GameObject.FindWithTag("NextSkin");
      GameObject BackSkinButton = GameObject.FindWithTag("BackSkin");
      GameObject PauseBackButton = GameObject.FindWithTag("PauseBack");
      GameObject PauseSettingsButton = GameObject.FindWithTag("PauseSetting");
      GameObject PlayButton2 = GameObject.FindWithTag("PlayButton2");
      GameObject BackButton2 = GameObject.FindWithTag("BackButton2");

      GameObject MusicSlider = GameObject.FindWithTag("MenuMusicSlider");
      GameObject SoundSlider = GameObject.FindWithTag("MenuSoundSlider");
      
      GameObject ScoreCounterGO = GameObject.FindWithTag("ScoreCounter");
      GameObject HealthBarGO = GameObject.FindWithTag("HealthBar");
      GameObject ShieldBarGO = GameObject.FindWithTag("ShieldBar");
      GameObject HighScoreCounterGO = GameObject.FindWithTag("Highscore");
      GameObject CurrentScoreGO = GameObject.FindWithTag("CurrentScore");
      GameObject ShipSelectionTextGO = GameObject.FindWithTag("ShipSelectionText");
      GameObject ShipStatSpeedGO = GameObject.FindWithTag("ShipStatSpeed");
      GameObject ShipStatFireRateGO = GameObject.FindWithTag("ShipStatFireRate");
      GameObject ShipStatHealthGO = GameObject.FindWithTag("ShipStatHealth");
      GameObject ShipStatShieldGO = GameObject.FindWithTag("ShipStatShield");

      GameObject DamageBorderGO = GameObject.FindWithTag("DamageBorder");

      characterS = GameObject.FindWithTag("character");

     // GameObject ReloadSpeedBuff = GameObject.FindWithTag("ReloadSpeedBuff");


      FullScreenText = GameObject.FindWithTag("FullscreenText");
      WindowText = GameObject.FindWithTag("WindowText");


    if(NextSkinButton){
        Button ButtonNSB = NextSkinButton.GetComponent<Button>();
        ButtonNSB.onClick.AddListener(delegate{NextSkin();});
    }

    if(BackSkinButton){
        Button ButtonBSB = BackSkinButton.GetComponent<Button>();
        ButtonBSB.onClick.AddListener(delegate{BackSkin();});
    }

    if(BackButton2){
        Button ButtonPB2 = BackButton2.GetComponent<Button>();
        ButtonPB2.onClick.AddListener(delegate{GameOverBack();});
      }

    if(PlayButton2){
        Button ButtonP2 = PlayButton2.GetComponent<Button>();
        ButtonP2.onClick.AddListener(delegate{StartGame();});
    }




    if(SoundSlider){
        SliderS = SoundSlider.GetComponent<Slider>();
        SliderS.onValueChanged.AddListener(delegate{ChangeSoundVolume(SliderS.value);});
        SliderS.value = soundVolume;
    }

    if(MusicSlider){
        SliderM = MusicSlider.GetComponent<Slider>();
        SliderM.onValueChanged.AddListener(delegate{ChangeMusicVolume(SliderM.value);}); 
        SliderM.value = musicVolume;
        
    }



    if(PauseSettingsButton){
        Button ButtonPS = PauseSettingsButton.GetComponent<Button>();
        ButtonPS.onClick.AddListener(delegate{PauseSettings();});
        Debug.Log("PauseSettingsBtn");
    }


    if(ChangeShipButton){
        Button ButtonChS = ChangeShipButton.GetComponent<Button>();   
        ButtonChS.onClick.AddListener(delegate{SelectShip();});
    }

    if(ShipStatShieldGO){
        ShipStatShield = ShipStatShieldGO.GetComponent<Text>();
    }

    if(ShipStatHealthGO){
        ShipStatHealth = ShipStatHealthGO.GetComponent<Text>();
    }

    if(ShipStatFireRateGO){
        ShipStatFireRate = ShipStatFireRateGO.GetComponent<Text>();
    }

    if(ShipStatSpeedGO){
        ShipStatSpeed = ShipStatSpeedGO.GetComponent<Text>();
    }

   if(ShipSelectionTextGO){
       ShipSelectionText = ShipSelectionTextGO.GetComponent<Text>();
   }

    if(ShieldBarGO){
        ShieldBar = ShieldBarGO.GetComponent<TextMeshPro>();
    }
    
    if(HealthBarGO){
        HealthBar = HealthBarGO.GetComponent<TextMeshPro>();
        
    }

    if(ScoreCounterGO){
        ScoreCounter = ScoreCounterGO.GetComponent<TextMeshPro>();
    }

    if(HighScoreCounterGO){
        HighScoreCounter = HighScoreCounterGO.GetComponent<Text>();
    }

    if(CurrentScoreGO){
        CurrentScore = CurrentScoreGO.GetComponent<Text>();
    }
     
     
     
      if(ResumeButton){
        Button ButtonRe = ResumeButton.GetComponent<Button>();   
        ButtonRe.onClick.AddListener(delegate{ResumeGame();});
      }

      if(PlayButton){
        Button ButtonP = PlayButton.GetComponent<Button>();   
        ButtonP.onClick.AddListener(delegate{StartGame();});
      }
     
      if(OptionsButton){
        Button ButtonO = OptionsButton.GetComponent<Button>();
        ButtonO.onClick.AddListener(delegate{OptionsMenu();});
      }
      if(ExitButton){
        Button ButtonE = ExitButton.GetComponent<Button>();
        ButtonE.onClick.AddListener(delegate{ExitGame();});
      }
      
      if(BackButton){
        Button ButtonB = BackButton.GetComponent<Button>();
        ButtonB.onClick.AddListener(delegate{GoBack();});
      }

      if(FullScreenButton){
          Button ButtonF = FullScreenButton.GetComponent<Button>();
          ButtonF.onClick.AddListener(delegate{FullScreen();});
           Debug.Log("FullBTNActive");
      }

      if(ResolutionButton){
          Button ButtonR = ResolutionButton.GetComponent<Button>();
          ButtonR.onClick.AddListener(delegate{FullScreen();});
      }

      if(PauseBackButton){
        Button ButtonPB = PauseBackButton.GetComponent<Button>();
        ButtonPB.onClick.AddListener(delegate{BackPause();});
      }

    
}

    public void ShowShip(){
        
        Character ch = CD.GetCharacter(ShowShipIndex);
        if(characterS){
            characterS.GetComponent<Image>().sprite = ch.characterSprite;
        }

    }

    public void NextSkin(){
        ShowShipIndex ++;
        if(ShowShipIndex > CD.GetCharactersCount()){
            ShowShipIndex = 1;
        }
        ShowShip();

    }


    public void BackSkin(){
        ShowShipIndex --;
        if(ShowShipIndex <= 0){
            ShowShipIndex = CD.GetCharactersCount();
        }
        ShowShip();
    }


    public void GameOverBack(){
        SceneManager.LoadScene("MainMenu");
        GameMusicGO.SetActive(false);
        MenuMusicGO.SetActive(true);
    }

    public void BackPause(){
        PauseMenuCanvasGO.SetActive(true);
        PauseSettingsCanvasGO.SetActive(false);
        GameOverCanvasGO.SetActive(false);
    }

    public void PauseSettings(){
        PauseMenuCanvasGO.SetActive(false);
        PauseSettingsCanvasGO.SetActive(true);
        GameOverCanvasGO.SetActive(false);
        LoadGameObject();
        CheckResolution();
    }


   public void CheckResolution(){
      
      if(WindowText && FullScreenText){
      
      
            if(Screen.fullScreen == true){
                WindowText.SetActive(false);
     
            }else{
                FullScreenText.SetActive(false);

            }
       }
   }

   
    void ResumeGame(){
        PauseMenuOFF();
        Cursor.visible = false;
    }


   public void FullScreen(){
       
       Debug.Log("FullScreenBtn");
       Debug.Log(FullScreenText);
       Debug.Log(WindowText);

        if(FullScreenText && WindowText){



       if(Screen.fullScreen == true){
           
       Screen.SetResolution(1280, 720, false);
        FullScreenText.SetActive(false);
        WindowText.SetActive(true);
        Debug.Log("wndw");

        


        }else{
            Screen.SetResolution(1920, 1080, true);
            Debug.Log("Fulscrn");

        WindowText.SetActive(false);
        FullScreenText.SetActive(true);
            
        }
   }

 }

   void GoBack(){
       SceneManager.LoadScene("MainMenu");
       Time.timeScale=1;
       GameMusicGO.SetActive(false);
       MenuMusicGO.SetActive(true);

   }
      
   
   void ExitGame(){
       Application.Quit();
    
   }
   
   
   void OptionsMenu(){
      
       SceneManager.LoadScene("OptionsMenu");
        
   }


    void Start(){
        
        FireSound = Resources.Load<AudioClip> ("Sprites/Music&Sound/FireSound");
        BtnSound = Resources.Load<AudioClip> ("Sprites/Music&Sound/BtnSound");

        AudioSrc = GetComponent<AudioSource> ();

  /*    MenuMusic.GetFloat("MenuMusic", SliderM.value);
        GameMusic.GetFloat("GameMusic", SliderM.value);
        SoundMusic.GetFloat("SoundMusic", SliderM.value);
*/
        PauseMenuOFF();
        PauseSettingsCanvasGO.SetActive(false);
        GameOverCanvasGO.SetActive(false);
        Time.timeScale=1;
        MenuMusicGO.SetActive(true);
        GameMusicGO.SetActive(false);
        CD = new CharacterDatabase();
        Debug.Log(CD.GetCharacter(1));

        float music = PlayerPrefs.GetFloat("MenuMusic",10f);
        ChangeMusicVolume(music);
        

      //   CM = CharacterManager.GetInstance();
         
       
    }

    void SelectShip(){
        SceneManager.LoadScene("ShipSelection");
    }

    void StartGame()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
        GameMusicGO.SetActive(true);
        MenuMusicGO.SetActive(false);
        Debug.Log(HighScore);

    }

    public void LoadPlayer(){
        GameObject playerSpawner = GameObject.FindWithTag("playerSpawner");
        Character ch = CD.GetCharacter(ShowShipIndex);
        Debug.Log(ch.characterShip.name);
        GameObject P = Instantiate(ch.characterShip, new Vector3(0, 0, 0), Quaternion.identity);
        MaxPlayerHP = ch.MaxPlayerHP;
        CurrentPlayerHP = ch.CurrentPlayerHP;
        Shield = ch.Shield;
        MaxPlayerShield = ch.MaxPlayerShield;
        PlayerSpeed = ch.PlayerSpeed;
        ReloadTime = ch.ReloadTime;
        P.transform.position = playerSpawner.transform.position;

    }

    // Update is called once per frame
   public void Update()
    {


    if(CurrentPlayerHP <= 0){
        CurrentPlayerHP = 0;
    }
    if(ShieldBar){
    ShieldBar.text = "Shield: " + Shield;
    }
    if(HealthBar){
    HealthBar.text = "Health: " + CurrentPlayerHP;
    }
    if(ScoreCounter){
    ScoreCounter.text = "Score: " + KillCount;
    }

    if(HighScoreCounter && CurrentScore){
    
        CurrentScore.text = "New score: " + KillCount;
        HighScoreCounter.text = "Best score: " + HighScore;
    }

    if(ShipSelectionText && ShipStatHealth && ShipStatFireRate && ShipStatShield && ShipStatSpeed){
        Character ch = CD.GetCharacter(ShowShipIndex);
        ShipSelectionText.text = "" + ch.characterName;
        ShipStatHealth.text = "Health: " + ch.MaxPlayerHP;
        ShipStatFireRate.text = "FireRate: " + ch.ReloadTime;
        ShipStatShield.text = "Shield: " + ch.MaxPlayerShield;
        ShipStatSpeed.text = "Speed: " + ch.PlayerSpeed;
    }


    Scene scene = SceneManager.GetActiveScene();
    
    

    if(scene.name == "Game"){

        
            if(Input.GetKeyDown(KeyCode.Escape) ){
         
                if(CurrentPlayerHP == 0){
                    GoBack();   
                }
                else if(PauseMenuCanvasGO.activeSelf == false){
                    PauseMenuON();             
                    Debug.Log("zmackl si esc");
                    Cursor.visible = true;
                
                }else{
                  //  PauseMenuOFF();
                    Cursor.visible = false;
                }
         
            }       
        }
    
              
              
          
    }
    public void PauseMenuON(){
        PauseMenuCanvasGO.SetActive(true);
         Time.timeScale = 0;
         PauseMenuCheck = false;         
         Debug.Log("PauseMenuON");
         PauseSettingsCanvasGO.SetActive(false);
         GameOverCanvasGO.SetActive(false);

         
    }

    public void PauseMenuOFF(){
        PauseMenuCanvasGO.SetActive(false);
        Time.timeScale = 1;
        PauseMenuCheck = true;
        Debug.Log("PauseMenuOFF");


    }

    public void MeteorExplosionEffect(Vector3 V3){
        Instantiate(MeteorExplosionPrefab, V3, Quaternion.identity);

    }

     public void EnemyExplosionEffect(Vector3 V3){
        Instantiate(EnemyExplosionPrefab, V3, Quaternion.identity);

    }


    
    
         
    
}
