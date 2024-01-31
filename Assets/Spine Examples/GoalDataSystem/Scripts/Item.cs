using System;
using UnityEngine;

public enum ItemName
{
    Keyboard,
    MagicHat,
    AcrobaticBall,
    Knife
}
public class Item : MonoBehaviour 
{
    public ItemName itemName;
    public ItemType type;
    public bool needMultiple = false;
    public int limitEndurance = 3;
    public int currentEndurance;
    public double baseFondValue = 15;
    public int price = 0;
    public string describeText;
    public double specialEffectRatio = 0.15f;

    private void Start()
    {
        currentEndurance = limitEndurance;
    }
    private void Update()
    {
        UpdateType();
    }

    // 将 ItemType 与 ItemName 绑定 
    private void UpdateType()
    {
        if (itemName == ItemName.Keyboard || itemName == ItemName.Knife)
            type = ItemType.Weapon;
        else if (itemName == ItemName.MagicHat)
            type = ItemType.Magic;
        else if (itemName == ItemName.AcrobaticBall)
            type = ItemType.Acrobatics;
    }

    // 减小耐久，在 Controller 中调用
    public void ReduceEndurance()
    {
        currentEndurance--;

        if (currentEndurance == 0)
        {
            DestoryItem();
        }
    }

    public void DestoryItem()
    {
        Destroy(gameObject);
    }
}
