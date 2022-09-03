using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character
{
    public string characterName;
    public Sprite characterSprite;
    public GameObject characterShip;
    
    public int id;
    public int MaxPlayerHP;
    public int CurrentPlayerHP;
    public int Shield;
    public int MaxPlayerShield;
    
    public float PlayerSpeed;
    public float ReloadTime;

    public Character(
                    int _id,
                    string _characterName, 
                    GameObject _characterShip, 
                    Sprite _characterSprite,  
                    int _MaxPlayerHP,
                    int _CurrentPlayerHP,
                    int _Shield,
                    int _MaxPlayerShield,
                    float _PlayerSpeed,
                    float _ReloadTime
                    ){
                        id = _id;
                        characterName = _characterName;
                        characterSprite = _characterSprite;
                        characterShip = _characterShip;
                        MaxPlayerHP = _MaxPlayerHP;
                        CurrentPlayerHP = _CurrentPlayerHP;
                        Shield = _Shield;
                        MaxPlayerShield = _MaxPlayerShield; 
                        PlayerSpeed = _PlayerSpeed;
                        ReloadTime = _ReloadTime;
                    }
}
