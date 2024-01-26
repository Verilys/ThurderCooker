using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:a26bf850-8e0c-42d1-b923-a69aa8c1b9d1
	public partial class UIGameFloatPanel
	{
		public const string Name = "UIGameFloatPanel";
		
		[SerializeField]
		public TMPro.TextMeshProUGUI txtVersion;
		
		private UIGameFloatPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			txtVersion = null;
			
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
