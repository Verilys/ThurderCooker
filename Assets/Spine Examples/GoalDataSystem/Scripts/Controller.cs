using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Character mainActor;
    public Character subActor;
    public List<Audience> audienceList;
    // ƥ�䲹�������ڼ���ƫ��ϵ�� GetFondFactor()
    public double constMatchFactor = 1.5;
    public Item handleItem;
    // ���ʲ�
    public int money = 1000;
    // �����Ƿ񴥷�����Ч��
    public bool isSpecial = false;

    public GameObject audienceObject;
    public GameObject audienceParent;

    
    // �����Ա��Ӧ       0������1������¹��2�����ӣ�3����������4������Ͱ��5�����̣�6���緹��
    private int[] preferFactor;

    private void Start()
    {
        isSpecial = false;

        // ��ʼ������
        preferFactor = new int[7];
        for (int i = 0; i < 7; i++)
            preferFactor[i] = 0;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GenerateAudience();
            //Debug.Log($"Race: {audienceList[audienceList.Count - 1].race}, Prefer Item: {audienceList[audienceList.Count - 1].preferItemType}");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            IsSpecial();
            //Debug.Log($"{preferFactor[0]}, {preferFactor[1]}, {preferFactor[2]}, {preferFactor[3]}, {preferFactor[4]}, {preferFactor[5]}, {preferFactor[6]}");
            
            UpdatePreferFactor();

            UpdateFondValue();

            UpdateMoney();

            // �Ե�ǰ���ߵ��;ý��㣬DestoryItem() ������GameObject�� ���ڶ���ִ��֮��
            
            if (handleItem.itemName == ItemName.Keyboard && isSpecial)
                handleItem.DestoryItem();
            else 
                handleItem.ReduceEndurance();

            //Debug.Log($"{preferFactor[0]}, {preferFactor[1]}, {preferFactor[2]}, {preferFactor[3]}, {preferFactor[4]}, {preferFactor[5]}, {preferFactor[6]}");
        }

        

    }
    
    public void GenerateAudience()
        {
            
            var audience = audienceObject.GetComponent<Audience>();
            // ???????????
            int randomValue = UnityEngine.Random.Range(0, 6);
            switch (randomValue)
            {
                case 0:
                    audience.character.race = Race.Animal;
                    audience.character.characterType = UnityEngine.Random.Range(0f, 1f) < 0.5 ? CharacterType.Dog : CharacterType.Giraffe;
                    break;
                case 1:
                    audience.character.race = Race.Vegetable;
                    audience.character.characterType = UnityEngine.Random.Range(0f, 1f) < 0.5 ? CharacterType.Eggplant : CharacterType.Tomato;
                    break;
                case 2:
                    audience.character.race = Race.Machine;
                    randomValue = UnityEngine.Random.Range(0, 2);
                    if (randomValue == 0)
                        audience.character.characterType = CharacterType.TrashCan;
                    else if (randomValue == 1)
                        audience.character.characterType = CharacterType.Keyboard;
                    else
                        audience.character.characterType = CharacterType.Cooker;
                    break;
                default:
                    break;
            }

            // ?????????????
            float randomValue2 = UnityEngine.Random.Range(0.0f, 1.0f);
            switch (audience.character.race)
            {
                case Race.Animal:
                    if (randomValue2 < audience.racePreferRatio)
                    {
                        audience.preferItemType = ItemType.Weapon;
                    }
                    else
                    {
                        randomValue2 = UnityEngine.Random.Range(0.0f, 1.0f);
                        if (randomValue2 > 0.5)
                            audience.preferItemType = ItemType.Magic;
                        else
                            audience.preferItemType = ItemType.Acrobatics;
                    }
                    break;
                case Race.Vegetable:
                    if (randomValue2 < audience.racePreferRatio)
                    {
                        audience.preferItemType = ItemType.Acrobatics;
                    }
                    else
                    {
                        randomValue2 = UnityEngine.Random.Range(0.0f, 1.0f);
                        if (randomValue2 > 0.5)
                            audience.preferItemType = ItemType.Magic;
                        else
                            audience.preferItemType = ItemType.Weapon;
                    }
                    break;
                case Race.Machine:
                    if (randomValue2 < audience.racePreferRatio)
                    {
                        audience.preferItemType = ItemType.Magic;
                    }
                    else
                    {
                        randomValue2 = UnityEngine.Random.Range(0.0f, 1.0f);
                        if (randomValue2 > 0.5)
                            audience.preferItemType = ItemType.Weapon;
                        else
                            audience.preferItemType = ItemType.Acrobatics;
                    }
                    break;
                default:
                    break;
            }
            Audience audObject = Instantiate(audience);
            audObject.transform.SetParent(audienceParent.transform);
            audObject.transform.localPosition = new Vector3(0,0,0);
            audObject.transform.localScale = new Vector3(1,1,1);

            UpdateAudienceStateUI(audObject);

            audienceList.Add(audObject);
        }

    // ���� ��ɫ���� ����ȡ PreferFactor���� ��Ӧ������
    private int GetIndex(CharacterType type)
    {
        int res;
        switch (type)
        {
            case CharacterType.Dog:
                res = 0;
                break;
            case CharacterType.Giraffe:
                res = 1;
                break;
            case CharacterType.Eggplant:
                res = 2;
                break;
            case CharacterType.Tomato:
                res = 3;
                break;
            case CharacterType.TrashCan:
                res = 4;
                break;
            case CharacterType.Keyboard:
                res = 5;
                break;
            case CharacterType.Cooker:
                res = 6;
                break;
            default:
                res = -1;
                break;
        }
        return res;
    }
    
    // �ж��Ƿ񴥷���������Ч��
    private void IsSpecial()
    {
        float randomValue = UnityEngine.Random.Range(0f, 1f);
        if (randomValue < handleItem.specialEffectRatio)
            isSpecial = true;
        else
            isSpecial = false;
    }

    // ����ƫ��ϵ������
    private void UpdatePreferFactor()
    {
        switch (handleItem.itemName)
        {
            case ItemName.Keyboard:
                if (isSpecial)
                {
                    // ���⣺��е -1������ 3
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == GetIndex(CharacterType.TrashCan) || i == GetIndex(CharacterType.Keyboard) || i == GetIndex(CharacterType.Cooker))
                            preferFactor[i] = -1;
                        else
                            preferFactor[i] = 3;
                    }
                } else {
                    // һ�㣺ȫΪ 1
                    for (int i = 0; i < 7; i++)
                        preferFactor[i] = 1;
                }
                break;
            case ItemName.MagicHat:
                if (isSpecial)
                {
                    // ���⣺���� -1������ 3
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == GetIndex(CharacterType.Dog) || i == GetIndex(CharacterType.Giraffe))
                            preferFactor[i] = -1;
                        else
                            preferFactor[i] = 3;
                    }
                }
                else
                {
                    // һ�㣺ȫΪ 1
                    for (int i = 0; i < 7; i++)
                        preferFactor[i] = 1;
                }
                break;
            case ItemName.AcrobaticBall:
                if (isSpecial)
                {   
                    // ���⣺ȫΪ 2
                    for (int i = 0; i < 7; i++)
                        preferFactor[i] = 2;
                }
                else
                {
                    // һ�㣺�� 3������ 1
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == GetIndex(CharacterType.Dog))
                            preferFactor[i] = 3;
                        else
                            preferFactor[i] = 1;
                    }
                }
                break;
            case ItemName.Knife:
                if (isSpecial)
                {
                    // ���⣺�α���������-2������ 4
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == GetIndex(subActor.characterType))
                            preferFactor[i] = -2;
                        else
                            preferFactor[i] = 4;
                    }
                }
                else
                {
                    // һ�㣺ȫΪ 2
                    for (int i = 0; i < 7; i++)
                        preferFactor[i] = 2;
                }
                break;
            default:
                break;
        }
    }

    // �ʲ�����
    public void UpdateMoney()
    {
        foreach (var i in audienceList)
        {
            if (i.audienceState == AudienceState.Laugh)
            {
                money += Convert.ToInt32(i.currentFondValue);
            }
        }
    }

    // ���ں���ֵ���� ����Ҫ�����¼���
    public void UpdateFondValue()
    {
        foreach (var i in audienceList)
        {
            i.currentFondValue = GetCurrentFondValue(i);
            UpdateAudienceState(i);
            UpdateAudienceStateUI(i);
            Debug.Log(i.currentFondValue);
        }
    }

        // ����״̬����
    public void UpdateAudienceState(Audience audience)
    {
        if (audience.currentFondValue < 100)
        {
            audience.audienceState = AudienceState.Angry;
        } 
        else if (audience.currentFondValue >= 200)
        {
            audience.audienceState = AudienceState.Laugh;
        }
        else
        {
            audience.audienceState = AudienceState.Normal;
        }
    }

    public void UpdateAudienceStateUI(Audience audience)
    {
        Slider slider = audience.GetComponentInChildren<Slider>();
        
        Debug.Log((float)(audience.currentFondValue / 300));

        slider.value = (float)(audience.currentFondValue / 300);

    }

    // ���� �������� ���պ���ֵ
    public double GetCurrentFondValue(Audience audience)
    {
        double final = GetDeltaFondValue(audience) + audience.currentFondValue;
        if (final < 0)
            final = 0;
        else if (final > 300)
            final = 300;
        return final;
    }

    // ���� �������� ����ֵ�仯��
    public double GetDeltaFondValue(Audience audience)
    {
        return GetFondFactor(audience) * handleItem.baseFondValue;
    }

    // ���� �������� �ĺ���ϵ��
    public double GetFondFactor(Audience audience)
    {

        int preferFactorValue = preferFactor[GetIndex(audience.character.characterType)];
        if (audience.preferItemType == handleItem.type) {
            return preferFactorValue * constMatchFactor;
        } else {
            return preferFactorValue;
        }
    }


}
