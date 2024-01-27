using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UnityEngine.Serialization;

namespace QFramework.ThunderCooker
{
    //定义一个 Model 对象
    public class DataModel : AbstractModel
    {
        //在此定义属性
        private int mDays;
        private int mScores;
        private int mCoins;
        private int mtime;
        public int Days
        {
            get => mDays;
            set 
            {
                if(mDays != value)
                {
                    mDays = value;
                }
                else if (mDays < 0)
                {
                    Debug.Log("天数不能为负！");
                }
            }
            
        }
        
        public int Scores
        {
            get => mScores;
            set 
            {
                if(mScores != value)
                {
                    mScores = value;
                }
                else if (mScores < 0)
                {
                    Debug.Log("数据不能为负！");
                }
            }
        }

        public int Coins
        {
            get => mCoins;
            set
            {
                mCoins = value;
            }
        }

        public bool isWin = false;
        public GameObject[] characters;

        // public class SlotA
        // {
        //     public Actor actor;
        //     public int Count;
        // }
        // public class SlotB
        // {
        //     public Item item;
        //     public int Count;
        // }
        public class Good
        {
            public int Price;
            public bool Perchased;
        }
        [System.Serializable]
        public class Actor
        {
            public GameObject actorPrefab;
            public string actorName;
            public int actorPrice;

            public Actor(string name, int price)
            {
                actorName = name;
                actorPrice = price;
            }
        }
        // public class Actor : Good
        // {
        //     public string Name;
        //     public string Key;
        // }
        public class Item : Good
        {
            public string Name;
            public string Key;
        }

        public class circusLibrary
        {
            //Actors
            public List<Actor> ActorShop;
            public List<Actor> ActorLib;
            
            //Items
            public List<Item> ItemShop;
            public List<Item> ItemLib;

            public void Purchase(List<Good> shop, List<Good> lib, Good good, DataModel model)
            {
                if (!shop.Contains(good) || lib.Contains(good))
                {
                    Debug.Log("Goods invalid");
                    return;
                }
                if (model.Coins >= good.Price)
                {
                    Debug.Log("Purchase Successful");
                    lib.Add(good);
                    shop.Remove(good);
                    model.Coins -= good.Price;
                }
            }
        }

        public circusLibrary circusLib = new circusLibrary();

        protected override void OnInit()
        {
            
        }
        
        
        
        
    }    
}

