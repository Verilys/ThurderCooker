using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:dec0b3e8-ece6-47d2-8a02-0ee1af7e5488
	public partial class UIEndPanel
	{
		public const string Name = "UIEndPanel";
		
		[SerializeField]
		public TMPro.TextMeshProUGUI txt_ending;
		[SerializeField]
		public UnityEngine.UI.Button backBtn;
		
		private UIEndPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			txt_ending = null;
			backBtn = null;
			
			mData = null;
		}
		
		public UIEndPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIEndPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIEndPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
