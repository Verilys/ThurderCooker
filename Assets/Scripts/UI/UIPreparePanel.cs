using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	public class UIPreparePanelData : UIPanelData
	{
	}
	public partial class UIPreparePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIPreparePanelData ?? new UIPreparePanelData();
			// please add init code here
			startPickBtn.onClick.AddListener((() =>
            {
            	UIKit.OpenPanel<UIPickPanel>();
            	this.CloseSelf();
            }));
			SwitchState(1);
			propsShopBtn.onClick.AddListener((() =>
			{
				SwitchState(2);
			}));
			actorsShopBtn.onClick.AddListener((() =>
			{
				SwitchState(3);
			}));
			pBackBtn.onClick.AddListener((() =>
			{
				SwitchState(1);
			}));
			aBackBtn.onClick.AddListener((() =>
			{
				SwitchState(1);
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
		
		public void SwitchState(int state)
		{
			switch (state)
			{
				case 1: 
					goalPanel.SetActive(true);
					porpsPanel.SetActive(false);
					actorsPanel.SetActive(false);
					break;
				case 2:
					goalPanel.SetActive(false);
					porpsPanel.SetActive(true);
					actorsPanel.SetActive(false);
					break;
				case 3:
					goalPanel.SetActive(false);
					porpsPanel.SetActive(false);
					actorsPanel.SetActive(true);
					break;
				
			}
			
		}
	}
}
