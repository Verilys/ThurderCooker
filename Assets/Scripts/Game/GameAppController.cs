using System;
using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace QFramework.ThunderCooker
{
    public class GameAppController : MonoBehaviour, IController
    {
        private static GameAppController instance;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
            //注册事件
            this.RegisterEvent<GameStartEvent>(e=>{
            });
        }

        void Start()
        {
            AudioKit.PlayMusic("首页教程BGM",true);
        }
        void Update()
        {
            
        }
        
        public IArchitecture GetArchitecture()
        {
            return GameApp.Interface;
        }

    }    
}

