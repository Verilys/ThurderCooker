using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	public class UISurePromptData : UIPanelData
	{
	}
	public partial class UISurePrompt : UIPanel, IController
	{
		public bool isPurchase = false;
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UISurePromptData ?? new UISurePromptData();
			var mModel = this.GetModel<DataModel>();		
			// please add init code here

			yesBtn.onClick.AddListener((() =>
			{
				UIPreparePanel mPrepare = UIKit.GetPanel<UIPreparePanel>();
				UIActorProperty mActor = mPrepare.currentActor.GetComponent<UIActorProperty>();
				Debug.Log(mActor.name+"钱"+mActor.price);
				// 检查玩家是否有足够的金币购买角色
				if (mModel.Coins >= mActor.price)
				{
					// 扣除金币
					mModel.Coins -= mActor.price;
					
					// 将角色从商店移动到已购买库
					mPrepare.controller.PurchaseCharacter(mPrepare.currentActor);
					mPrepare.controller.UpdateUI();
					Debug.Log("购买成功！");
					UIKit.GetPanel<UIPreparePanel>().txt_money.text = mModel.Coins.ToString();
				}
				else
				{
					UIKit.OpenPanel<UIGoldPrompt>();
					Debug.Log("购买失败！");
				}
				this.CloseSelf();
			}));
			
			noBtn.onClick.AddListener((() =>
			{
				this.CloseSelf();
			}));
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
		public IArchitecture GetArchitecture()
		{
			return GameApp.Interface;
		}
	}
}
