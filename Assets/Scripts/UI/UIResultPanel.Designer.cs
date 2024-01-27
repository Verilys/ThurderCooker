using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:f32e919f-f65a-450e-8d6a-24ad52945f5c
	public partial class UIResultPanel
	{
		public const string Name = "UIResultPanel";
		
		[SerializeField]
		public TMPro.TextMeshProUGUI txt_income;
		[SerializeField]
		public TMPro.TextMeshProUGUI txt_icome;
		[SerializeField]
		public UnityEngine.UI.Button nextBtn;
		
		private UIResultPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			txt_income = null;
			txt_icome = null;
			nextBtn = null;
			
			mData = null;
		}
		
		public UIResultPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIResultPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIResultPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
