using UnityEngine;
using UnityEngine.UI;
using QFramework;
using TMPro;

namespace QFramework.ThunderCooker
{
	public class UIPreparePanelData : UIPanelData
	{
	}
	public partial class UIPreparePanel : UIPanel, IController
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIPreparePanelData ?? new UIPreparePanelData();
			// please add init code here
			var mModel = this.GetModel<DataModel>();
			txt_money.text = mModel.Coins.ToString();
			var foundObject = GameObject.Find("CharacterController");
			if (foundObject != null)
			{
				Debug.Log("找到物体：" + foundObject.name);
				controller = foundObject.GetComponent<CharacterController>();
				foreach (var actor in controller.shopCharacters)
                {
                    //实例化角色
                    currentActor = Instantiate(actor, actors);
                    currentActor.name = actor.GetComponent<UIActorProperty>().name;
                    Button purchaseBtn = currentActor.GetComponent<Button>();
                    bool isPurchase = currentActor.GetComponent<UIActorProperty>().isPurchase;
                    //如果人物按钮已经被购买
                    if (isPurchase)
                    {
	                    purchaseBtn.interactable = false;
                    }
                    else
                    {
	                    purchaseBtn.onClick.AddListener(() =>
	                    {
		                    currentActor = purchaseBtn.gameObject;
		                    UIKit.OpenPanel<UISurePrompt>();
		                    //this.SendCommand<PurchaseCommand>();
	                    });    
                    }

                }
			}
			else
			{
				Debug.LogWarning("未找到物体");
			}
			
			startPickBtn.onClick.AddListener((() =>
            {
            	UIKit.OpenPanel<UIPickPanel>();
            	this.CloseSelf();
            }));
			SwitchState(1);
			propsShopBtn.onClick.AddListener((() =>
			{
				SwitchState(2);
			}));
			actorsShopBtn.onClick.AddListener((() =>
			{
				SwitchState(3);
			}));
			pBackBtn.onClick.AddListener((() =>
			{
				SwitchState(1);
			}));
			aBackBtn.onClick.AddListener((() =>
			{
				SwitchState(1);
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
		
		public void SwitchState(int state)
		{
			switch (state)
			{
				case 1: 
					goalPanel.SetActive(true);
					porpsPanel.SetActive(false);
					actorsPanel.SetActive(false);
					break;
				case 2:
					goalPanel.SetActive(false);
					porpsPanel.SetActive(true);
					actorsPanel.SetActive(false);
					break;
				case 3:
					goalPanel.SetActive(false);
					porpsPanel.SetActive(false);
					actorsPanel.SetActive(true);
					break;
				
			}
		}
		
		public IArchitecture GetArchitecture()
		{
			return GameApp.Interface;
		}
	}
}
