using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	public class UIGoldPromptData : UIPanelData
	{
	}
	public partial class UIGoldPrompt : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGoldPromptData ?? new UIGoldPromptData();
			// please add init code here
			backBtn.onClick.AddListener((() =>
			{
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
