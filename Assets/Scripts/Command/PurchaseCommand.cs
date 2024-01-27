using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.ThunderCooker
{
    public class PurchaseCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<DataModel>();
            
            // if (gameModel.Coins >= characterPrefab.actorPrice)
            // {
            //     // 扣除金币
            //     gameModel.Coins -= characterPrefab.actorPrice;
            //
            //     // 将角色从商店移动到已购买库
            //     shopCharacters.Remove(characterPrefab);
            //     purchasedCharacters.Add(characterPrefab);
            //
            //     Debug.Log("购买成功！");
            //     this.SendCommand<PurchaseSuccessCommand>();
            // }
            // else
            // {
            //     Debug.Log("金币不足，购买失败！");
            //     this.SendCommand<PurchaseFailCommand>();
            // }

        }
    }
}
