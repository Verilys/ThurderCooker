using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace QFramework.ThunderCooker
{
	public class UIResultPanelData : UIPanelData
	{
		public int targetScore = 1500;
	}
	public partial class UIResultPanel : UIPanel, IController
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIResultPanelData ?? new UIResultPanelData();
			
			var mModel = this.GetModel<DataModel>();
			txtDays.text = "剩余天数：" + (mModel.Days - 1);
			// please add init code here
			nextBtn.onClick.AddListener((() =>
			{
				AudioKit.PlaySound("click");
				mModel.Days--;
				txtDays.text = "剩余天数：" + (mModel.Days -1);
				
				if (mModel.Days == 0)
				{
					if (mModel.Scores >= mData.targetScore)
					{
						AudioKit.PlaySound("success");
						AudioKit.PauseMusic();
						mModel.isWin = true;
					}
					else
					{
						AudioKit.PlaySound("fail");
						AudioKit.PauseMusic();
						mModel.isWin = false;
					}
					
					UIKit.OpenPanel<UIEndPanel>();	
				}
				else
				{
					//下一天
					AudioKit.PlayMusic("幕前准备BGM",true);
					UIKit.OpenPanel<UIPreparePanel>();
					
				}
				
				var foundObject = GameObject.Find("CharacterController");
				controller = foundObject.GetComponent<CharacterController>();
				//重置场景
				foreach (Transform child in controller.characters.transform)
				{
					Destroy(child.gameObject);
				}
				// 清空子物体列表
				controller.characters.transform.DetachChildren();
				controller.packCharacters.Clear();
				this.SendCommand<TurnCurtainCommand>();
	
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
