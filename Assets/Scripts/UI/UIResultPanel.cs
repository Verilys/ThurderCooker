using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	public class UIResultPanelData : UIPanelData
	{
	}
	public partial class UIResultPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIResultPanelData ?? new UIResultPanelData();
			// please add init code here
			nextBtn.onClick.AddListener((() =>
			{
				
				UIKit.OpenPanel<UIEndPanel>();
				
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
