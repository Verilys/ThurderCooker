using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace QFramework.ThunderCooker
{
	public class UIPickPanelData : UIPanelData
	{
		public string targetSceneName = "MAIN Level";
	}
	public partial class UIPickPanel : UIPanel, IController
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIPickPanelData ?? new UIPickPanelData();
			// please add init code here
			
			var foundObject = GameObject.Find("CharacterController");
			if (foundObject != null)
			{
				Debug.Log("找到物体：" + foundObject.name);
				controller = foundObject.GetComponent<CharacterController>();
				foreach (var actor in controller.purchasedCharacters)
				{
					//实例化角色
					currentActor = Instantiate(actor, aContent);
					currentActor.name = actor.GetComponent<UIActorProperty>().name;
					Button pickBtn = currentActor.GetComponent<Button>();
					bool isPicked = currentActor.GetComponent<UIActorProperty>().isPicked;
					//如果人物按钮已经被挑选
					if (isPicked)
					{
						pickBtn.interactable = false;
					}
					else
					{
						pickBtn.onClick.AddListener(() =>
						{
							currentActor = pickBtn.gameObject;
							controller.AddToBackpack(currentActor);
							//this.SendCommand<PurchaseCommand>();
						});						
					}

				}
			}
			else
			{
				Debug.LogWarning("未找到物体");
			}
			
			
			nextBtn.onClick.AddListener((() =>
			{
				UIKit.OpenPanel<UIGameFloatPanel>(UILevel.PopUI);
				SceneManager.LoadScene(mData.targetSceneName);
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
