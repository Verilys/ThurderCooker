using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	public class UISettingsPanelData : UIPanelData
	{
	}
	public partial class UISettingsPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UISettingsPanelData ?? new UISettingsPanelData();
			// please add init code here
			backBtn.onClick.AddListener((() =>
			{
				UIKit.OpenPanel<UIStartPanel>();
				this.CloseSelf();
			}));
			audioBtn.onClick.AddListener((() =>
			{
				AudioKit.PlaySound("coin");
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
