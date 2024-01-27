using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.TestTools;

namespace QFramework.ThunderCooker
{
	public class UIGameFloatPanelData : UIPanelData
	{
		public int actTurn = 1;
	}
	public partial class UIGameFloatPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGameFloatPanelData ?? new UIGameFloatPanelData();
			// please add init code here
			
			nextBtn.onClick.AddListener((() =>
			{
				Debug.Log($"下一幕是第{mData.actTurn}幕");
				if (mData.actTurn == 3)
				{
					UIKit.OpenPanel<UIResultPanel>();
					this.Hide();	
				}
				else
				{
					
					mData.actTurn++;
				}
				
			}));
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			mData.actTurn = 1;
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
