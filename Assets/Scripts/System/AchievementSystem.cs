using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.ThunderCooker
{
    public class AchievementSystem : AbstractSystem
    {
        protected override void OnInit()
        {
            var model = this.GetModel<DataModel>();

            this.RegisterEvent<EndPerformEvent>(e =>
            {
                //计算获得金币
                if (model.audience.favorabilty == 1)
                {
                    model.audience.tips = 100;
                    Debug.Log("观众值1");
                }
                else if (model.audience.favorabilty == 0)
                {
                    model.audience.tips = 0;
                    Debug.Log("观众值0");
                }
                //结算金币
                model.Coins += model.audience.tips;
            });
        }
    }
}



