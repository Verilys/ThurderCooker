using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:04cc1c20-c0d5-4393-8041-5b70102f267e
	public partial class UIStartPanel
	{
		public const string Name = "UIStartPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button startBtn;
		[SerializeField]
		public UnityEngine.UI.Button settingBtn;
		[SerializeField]
		public UnityEngine.UI.Button exitBtn;
		
		private UIStartPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			startBtn = null;
			settingBtn = null;
			exitBtn = null;
			
			mData = null;
		}
		
		public UIStartPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIStartPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIStartPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
