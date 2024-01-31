using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace QFramework.ThunderCooker
{
	public class UIStartPanelData : UIPanelData
	{
	}
	public partial class UIStartPanel : UIPanel, IController
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIStartPanelData ?? new UIStartPanelData();
			// please add init code here
			startBtn.onClick.AddListener(() =>
			{
				Debug.Log("start game");
				AudioKit.PlaySound("click");
				this.SendCommand<StartGameCommand>();
				
				UIKit.OpenPanel<UITutorialPanel>();
				this.CloseSelf();
			});
			settingBtn.onClick.AddListener((() =>
			{
				AudioKit.PlaySound("click");
				UIKit.OpenPanel<UISettingsPanel>();
				this.CloseSelf();
			}));
			exitBtn.onClick.AddListener((() =>
			{
				AudioKit.PlaySound("click");
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
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
