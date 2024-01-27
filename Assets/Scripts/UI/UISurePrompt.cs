using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	public class UISurePromptData : UIPanelData
	{
	}
	public partial class UISurePrompt : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UISurePromptData ?? new UISurePromptData();
			// please add init code here
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
