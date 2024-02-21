using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace QFramework.ThunderCooker
{
	public class UIPickPanelData : UIPanelData
	{
		public GameObject mCurrentActor;
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
                            currentActor.GetComponentInChildren<UIActorProperty>().txtPrice.SetActive(false);
                            currentActor.GetComponent<Button>().onClick.AddListener(() => PickActor(mModel,actor));

                            if (currentActor.name == "Bin")
                            {
	                            currentActor.GetComponent<Button>().onClick.Invoke();
                            }
						}
					}
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
				
				objContrller = GameObject.Find("ObjectsController").GetComponent<ObjectsController>();
				
				this.SendCommand<TurnOffCurtainCommand>();
				
				ActiveCharacter(mModel.actorPickList);
				controller.packCharacters[0].GetComponent<BasicPlatformerController>().isControlled = true;
				this.CloseSelf();				
			}));

		}
		public void PickActor(DataModel mModel, DataModel.Actor actor)
		{
			print("选");
			//已经被选过
			if (actor.isPicked && mModel.actorPickList.Count > 1)
			{
				mModel.actorPickList.Remove(actor);
				actor.isPicked = false;
			}
			else
			{
				if (mModel.actorPickList.Count == 3)
            	{
            		print("移除多余角色");
            		mModel.actorPickList[0].isPicked = false;
            		mModel.actorPickList.RemoveAt(0);
            	}
            	actor.isPicked = true;
            	mModel.actorPickList.Add(actor);	
			}
			
			//更新icon
			foreach (Transform childTransform in aContent)
			{
				childTransform.GetComponentInChildren<UIActorProperty>().pickIcon.SetActive(false);	
				foreach (var item in mModel.actorPickList)
				{
					if (childTransform.gameObject.name == item.actorName)
					{
						childTransform.GetComponentInChildren<UIActorProperty>().pickIcon.SetActive(true);		
					}
				}
			}
		}
		private void ActiveCharacter(List<DataModel.Actor> pickList)
		{
			foreach (var actor in pickList)
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
