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
        public bool isCurtainOpen;
        public bool isWin = false;
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

        
        [System.Serializable]
        public class Actor
        {
            public string actorName;
            public string avatarName;
            public int price;
            public bool isPurchased;
            public bool isPicked;
            public Actor(string name, string uiName, int price)
            {
                actorName = name;
                avatarName = uiName;
                this.price = price;
                isPurchased = false;
                isPicked = false;
            }
        }

        public List<Actor> actorShopList = new List<Actor>();
        public List<Actor> actorPurchasedList = new List<Actor>();
        public List<Actor> actorPickList = new List<Actor>();

        protected override void OnInit()
        {
        }


        public class Audience
        {
            public int hotPints;
        }
        
    }    
}

