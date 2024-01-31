using System.Collections.Generic;
using System.Linq;
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
			startPickBtn.interactable= false;
			mData = uiData as UIPreparePanelData ?? new UIPreparePanelData();
			// please add init code here
			var mModel = this.GetModel<DataModel>();
			txt_money.text = mModel.Coins.ToString();
			var foundObject = GameObject.Find("CharacterController");
			if (foundObject != null)
			{
				Debug.Log("找到物体：" + foundObject.name);
				controller = foundObject.GetComponent<CharacterController>(); 
				HashSet<string> nameHashSet = new HashSet<string>(mModel.actorShopList.Select(actor => actor.avatarName));
				foreach (var ui_actor in controller.ui_Characters)
                {
	                //实例化ui角色
	                currentActor = Instantiate(ui_actor, actors);
	                currentActor.name = ui_actor.name;
	                Button purchaseBtn = currentActor.GetComponent<Button>();
	                // 检查名字是否存在于哈希集合中
	                if (nameHashSet.Contains(currentActor.name))
	                {
		                Debug.Log("在商店中，添加按钮监听"+currentActor.name);
		                
						purchaseBtn.onClick.AddListener(() =>
                        {
                            AudioKit.PlaySound("click");
                            Debug.Log("当前选择角色是" + purchaseBtn.gameObject.name);
                            UIKit.OpenPanel<UISurePrompt>(new UISurePromptData()
                            {
	                            mCurrentActor = purchaseBtn.gameObject,mController = controller
                            });
                            //this.SendCommand<PurchaseCommand>();
                        });        
	                }
	                else
	                {
		                purchaseBtn.interactable = false;
	                }

                }
			}
			else
			{
				Debug.LogWarning("未找到物体");
			}
			
			startPickBtn.onClick.AddListener((() =>
            {
	            AudioKit.PlaySound("click");
            	UIKit.OpenPanel<UIPickPanel>();
            	this.CloseSelf();
            }));
			SwitchState(1);
			propsShopBtn.onClick.AddListener((() =>
			{
				AudioKit.PlaySound("click");
				SwitchState(2);
			}));
			actorsShopBtn.onClick.AddListener((() =>
			{
				startPickBtn.interactable= true;
				AudioKit.PlaySound("click");
				SwitchState(3);
			}));
			pBackBtn.onClick.AddListener((() =>
			{
				AudioKit.PlaySound("click");
				SwitchState(1);
			}));
			aBackBtn.onClick.AddListener((() =>
			{
				AudioKit.PlaySound("click");
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
