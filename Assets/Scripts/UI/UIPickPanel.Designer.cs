using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:44b7e651-b1d1-448c-bb84-d6f12d4ed7f5
	public partial class UIPickPanel
	{
		public const string Name = "UIPickPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button nextBtn;
		
		private UIPickPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			nextBtn = null;
			
			mData = null;
		}
		
		public UIPickPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIPickPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIPickPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
