using System;
using UnityEngine;

public enum Race
{
    Animal,
    Vegetable,
    Machine
}

public enum CharacterType
{
    Dog,
    Giraffe,
    Eggplant,
    Tomato,
    TrashCan,
    Keyboard,
    Cooker
}

[System.Serializable]
public class Character // 继承BasicPlatformerController
{
    public Race race;
    public CharacterType characterType;

    public Character(Race race, CharacterType type)
    {
        this.race = race;
        this.characterType = type;
    }
}


