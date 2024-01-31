using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	public class UISurePromptData : UIPanelData
	{
		public GameObject mCurrentActor;
		public CharacterController mController;
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
				foreach (var actor in mModel.actorShopList)
				{
					if (actor.avatarName == mData.mCurrentActor.name)
					{
						Debug.Log(mData.mCurrentActor.name+"钱"+ actor.price);
						// 检查玩家是否有足够的金币购买角色
						if (mModel.Coins >= actor.price)
	                    {
	                        // 扣除金币
	                        mModel.Coins -= actor.price;
	                        
	                        // 将角色从商店移动到已购买库
	                        mData.mController.PurchaseCharacter(actor);
	                        mData.mCurrentActor.GetComponent<Button>().interactable = false;
	                       
	                        Debug.Log("购买成功！");
	                        AudioKit.PlaySound("buy");
	                        UIKit.GetPanel<UIPreparePanel>().txt_money.text = mModel.Coins.ToString();
	                    }
	                    else
	                    {
	                        UIKit.OpenPanel<UIGoldPrompt>();
	                        Debug.Log("购买失败！");
	                    }
						break;
					}
				}
				this.CloseSelf();
			}));
			
			noBtn.onClick.AddListener((() =>
			{
				AudioKit.PlaySound("click");
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
