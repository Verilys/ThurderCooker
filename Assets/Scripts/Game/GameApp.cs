using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace QFramework.ThunderCooker
{
    //定义一个架构（提供 MVC、分层、模块管理等）
    public class GameApp : Architecture<GameApp>
    {
        protected override void Init()
        {
            // 注册 Model
            this.RegisterModel(new DataModel());
            
        }
    }    
}

