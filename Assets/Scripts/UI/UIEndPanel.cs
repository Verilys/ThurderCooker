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
	public partial class UIEndPanel : UIPanel, IController
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIEndPanelData ?? new UIEndPanelData();
			var model = this.GetModel<DataModel>();
			// please add init code here
			
			//结局
			if (model.isWin)
			{
				txt_ending.text = "success";
			}
			else
			{
				txt_ending.text = "fail";
			}
			
			backBtn.onClick.AddListener((() =>
			{
				AudioKit.PlaySound("click");
				AudioKit.PlayMusic("首页教程BGM");
				Debug.Log("游戏结束，返回初始界面");
				var foundObject = GameObject.Find("CharacterController");
				Destroy(foundObject);
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
		public IArchitecture GetArchitecture()
		{
			return GameApp.Interface;
		}
	}
}
