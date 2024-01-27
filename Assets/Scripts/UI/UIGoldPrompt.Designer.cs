using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:6ff80f33-b24f-423d-aceb-fa3238563c99
	public partial class UIGoldPrompt
	{
		public const string Name = "UIGoldPrompt";
		
		[SerializeField]
		public UnityEngine.UI.Button backBtn;
		
		private UIGoldPromptData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			backBtn = null;
			
			mData = null;
		}
		
		public UIGoldPromptData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGoldPromptData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGoldPromptData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
