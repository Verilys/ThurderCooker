using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:51a5dc74-5e87-4755-a5a1-d2f8b8d36fa4
	public partial class UIGameFloatPanel
	{
		public const string Name = "UIGameFloatPanel";
		
		[SerializeField]
		public TMPro.TextMeshProUGUI txtVersion;
		[SerializeField]
		public UnityEngine.UI.Button nextBtn;
		
		private UIGameFloatPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			txtVersion = null;
			nextBtn = null;
			
			mData = null;
		}
		
		public UIGameFloatPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameFloatPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameFloatPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
