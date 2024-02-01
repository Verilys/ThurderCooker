using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:49b758b8-9da1-4c7b-a03d-799d4a10aa64
	public partial class UIResultPanel
	{
		public const string Name = "UIResultPanel";
		
		[SerializeField]
		public TMPro.TextMeshProUGUI txtDays;
		[SerializeField]
		public TMPro.TextMeshProUGUI txt_income1;
		[SerializeField]
		public TMPro.TextMeshProUGUI txt_income2;
		[SerializeField]
		public TMPro.TextMeshProUGUI txt_income3;
		[SerializeField]
		public UnityEngine.UI.Button nextBtn;
		
		public CharacterController controller;
		
		private UIResultPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			txtDays = null;
			txt_income1 = null;
			txt_income2 = null;
			txt_income3 = null;
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
