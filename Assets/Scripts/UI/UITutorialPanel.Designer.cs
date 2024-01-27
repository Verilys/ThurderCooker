using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:1b046d74-e558-490e-8529-9331cbe6a4cd
	public partial class UITutorialPanel
	{
		public const string Name = "UITutorialPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button nextBtn;
		
		private UITutorialPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			nextBtn = null;
			
			mData = null;
		}
		
		public UITutorialPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UITutorialPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UITutorialPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
