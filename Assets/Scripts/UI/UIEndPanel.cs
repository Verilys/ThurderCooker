using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;
namespace QFramework.ThunderCooker
{
	public class UIEndPanelData : UIPanelData
	{
		public string targetSceneName = "Main";
	}
	public partial class UIEndPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIEndPanelData ?? new UIEndPanelData();
			// please add init code here
			backBtn.onClick.AddListener((() =>
			{
				Debug.Log("游戏结束，返回初始界面");
				SceneManager.LoadScene(mData.targetSceneName);
				UIKit.OpenPanel<UIStartPanel>();
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
