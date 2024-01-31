using System;
using UnityEngine;
public enum ItemType
{
    Weapon,
    Magic,
    Acrobatics
}

public enum AudienceState
{
    Laugh,
    Normal,
    Angry
}

public class Audience : MonoBehaviour
{
    public Character character;

    public ItemType preferItemType;
    //??????????????0.6??????0.2??????-?????????-???????��-?????
    public double racePreferRatio = 0.6;
    public double initialFondValue = 150;
    public double currentFondValue;
    public AudienceState audienceState = AudienceState.Normal;


    void Start()
    {
        Initial();
    }

    public void Initial()
    {
        currentFondValue = initialFondValue;
        audienceState = AudienceState.Normal;
    }

    


}
