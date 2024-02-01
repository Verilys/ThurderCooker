using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace QFramework.ThunderCooker
{
	public class UIPickPanelData : UIPanelData
	{
	}
	public partial class UIPickPanel : UIPanel, IController
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIPickPanelData ?? new UIPickPanelData();
			// please add init code here
			var mModel = this.GetModel<DataModel>();
			
			var foundObject = GameObject.Find("CharacterController");
			if (foundObject != null)
			{
				Debug.Log("找到物体：" + foundObject.name);
				controller = foundObject.GetComponent<CharacterController>();
				foreach (var ui_actor in controller.ui_Characters)
				{
					foreach (var actor in mModel.actorPurchasedList)
					{
						if (actor.avatarName == ui_actor.name)
						{
							//实例化角色
                        	currentActor = Instantiate(ui_actor, aContent);
                            currentActor.name = actor.actorName;
						}
					}
					
					// Button pickBtn = currentActor.GetComponent<Button>();
					// bool isPicked = currentActor.GetComponent<UIActorProperty>().isPicked;
					// //如果人物按钮已经被挑选
					// if (isPicked)
					// {
					// 	pickBtn.interactable = false;
					// }
					// else
					// {
					// 	pickBtn.onClick.AddListener(() =>
					// 	{
					// 		currentActor = pickBtn.gameObject;
					// 		controller.AddToBackpack(currentActor);
					// 		//this.SendCommand<PurchaseCommand>();
					// 	});						
					// }

				}
			}
			else
			{
				Debug.LogWarning("未找到物体");
			}
			
			
			nextBtn.onClick.AddListener((() =>
			{
				Debug.Log("开始主场景");
				AudioKit.PlaySound("applaud", true);
				AudioKit.PlayMusic("表演BGM");
				UIKit.OpenPanel<UIGameFloatPanel>(UILevel.PopUI);
				
				GameObject obj = GameObject.Find("curtain");
				obj.SetActive(false);
				
				ActiveCharacter(mModel.actorPurchasedList);
				controller.packCharacters[0].GetComponent<BasicPlatformerController>().isControlled = true;
				this.CloseSelf();				
			}));

		}

		private void ActiveCharacter(List<DataModel.Actor> purchasedList)
		{
			foreach (var actor in purchasedList)
	        {
	            foreach (var spineActor in controller.spineCharacters)
	            {
            		if (actor.actorName == spineActor.name)
            		{
            			Debug.Log("开启"+spineActor.name);
                        GameObject curActor = Instantiate(spineActor,controller.characters.transform);
                        curActor.name = spineActor.name;
                        curActor.SetActive(true);
                        controller.packCharacters.Add(curActor);
                        
                    }
	            }
	        }
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

		public void OnItemPick(Button btn)
		{
			btn.interactable = false;
			
		}
		public IArchitecture GetArchitecture()
		{
			return GameApp.Interface;
		}
	}
}
