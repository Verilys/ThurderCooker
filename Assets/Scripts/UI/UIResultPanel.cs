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
			
			var gameModel = this.GetModel<DataModel>();
			
			// please add init code here
			nextBtn.onClick.AddListener((() =>
			{
				gameModel.Days--;
				Debug.Log("剩余天数："+gameModel.Days);
				
				if (gameModel.Days == 0)
				{
					if (gameModel.Scores >= mData.targetScore)
					{
						gameModel.isWin = true;
					}
					else
					{
						gameModel.isWin = false;
					}
					SceneManager.LoadScene("Prepare");
					UIKit.OpenPanel<UIEndPanel>();	
				}
				else
				{
					SceneManager.LoadScene("Prepare");
					UIKit.OpenPanel<UIPreparePanel>();
				}
				
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
