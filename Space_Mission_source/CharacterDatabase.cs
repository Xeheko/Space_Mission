using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabase
{
    public List<Character> character = new List<Character>();

    public int GetCharactersCount(){
        return character.Count;
    }

    public Character GetCharacter(int index){
        Character returnChar = null;
        foreach(var ch in character){
            if(ch.id == index ){
                returnChar = ch;
            }
        }
        return returnChar;
    }

    public CharacterDatabase(){
        GameObject Ship1 = Resources.Load <GameObject> ("Prefabs/Player/PlayerGO");
        Sprite Ship1S = Resources.Load <Sprite> ("Sprites/GameObjects/Lode/skins/lod_triangle");
        Character characterShip1 = new Character( 
            1,
            "Triangle Shadow",
            Ship1,
            Ship1S,
            100,
            100,
            30,
            30,
            8f,
            0.5f
        );
        character.Add(characterShip1);
        GameObject Ship2 = Resources.Load <GameObject> ("Prefabs/Player/PlayerGO_Sky");
        Sprite Ship2S = Resources.Load <Sprite> ("Sprites/GameObjects/Lode/skins/lod_triangle_skin");
        Character characterShip2 = new Character(
            2,
            "Triangle Sky",
            Ship2,
            Ship2S,
            100,
            100,
            30,
            30,
            8f,
            0.5f
        );
        character.Add(characterShip2);
        GameObject Ship3 = Resources.Load <GameObject> ("Prefabs/Player/PlayerGO_Forest");
        Sprite Ship3S = Resources.Load <Sprite> ("Sprites/GameObjects/Lode/skins/lod_circle");
        Character characterShip3 = new Character(
            3,
            "Cicrle Forest",
            Ship3,
            Ship3S,
            80,
            80,
            60,
            60,
            12f,
            0.5f
        );
        character.Add(characterShip3);
        GameObject Ship4 = Resources.Load <GameObject> ("Prefabs/Player/PlayerGO_Sun");
        Sprite Ship4S = Resources.Load <Sprite> ("Sprites/GameObjects/Lode/skins/lod_circle_skin");
        Character characterShip4 = new Character(
            4,
            "Cicrle Sun",
            Ship4,
            Ship4S,
            80,
            80,
            60,
            60,
            12f,
            0.5f
        );
        character.Add(characterShip4);
    }
}
