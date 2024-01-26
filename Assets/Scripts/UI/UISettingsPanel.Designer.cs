using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:2bd181a7-7616-4699-b74f-6383d0dcb7df
	public partial class UISettingsPanel
	{
		public const string Name = "UISettingsPanel";
		
		[SerializeField]
		public UnityEngine.UI.Image bg;
		[SerializeField]
		public UnityEngine.UI.Button backBtn;
		[SerializeField]
		public UnityEngine.UI.Button audioBtn;
		
		private UISettingsPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			bg = null;
			backBtn = null;
			audioBtn = null;
			
			mData = null;
		}
		
		public UISettingsPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UISettingsPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UISettingsPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
