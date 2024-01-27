using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace QFramework.ThunderCooker
{
	public class UIPickPanelData : UIPanelData
	{
		public string targetSceneName = "Level 1";
	}
	public partial class UIPickPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIPickPanelData ?? new UIPickPanelData();
			// please add init code here
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
	}
}
