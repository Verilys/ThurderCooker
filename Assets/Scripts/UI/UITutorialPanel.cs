using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	public class UITutorialPanelData : UIPanelData
	{
	}
	public partial class UITutorialPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UITutorialPanelData ?? new UITutorialPanelData();
			// please add init code here
			nextBtn.onClick.AddListener((() =>
			{
				UIKit.OpenPanel<UIPreparePanel>();
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
