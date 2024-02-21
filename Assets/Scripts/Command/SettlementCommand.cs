using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.ThunderCooker
{
    public class SettlementCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<DataModel>();
            this.SendEvent<EndPerformEvent>();
            UIKit.OpenPanel<UIResultPanel>();
        }
    }
}
