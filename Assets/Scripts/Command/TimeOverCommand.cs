using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.ThunderCooker
{
    public class TimeOverCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            // 
            UIKit.OpenPanel<UIResultPanel>();
            UIKit.ClosePanel<UIGameFloatPanel>();
        }
    }    
}

