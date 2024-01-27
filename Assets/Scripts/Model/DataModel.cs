using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

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


        public GameObject[] characters;
        
        protected override void OnInit()
        {
        }
        
        
        
        
    }    
}

