using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace QFramework.ThunderCooker
{
    public class TurnCurtainCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<DataModel>();
            gameModel.isCurtainOpen = true;
            this.SendEvent<CurtainEvent>();
        }
    }    
}

