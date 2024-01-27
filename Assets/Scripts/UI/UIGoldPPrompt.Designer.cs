using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:3195cba2-cbd5-4fb2-9657-a6b072e649a8
	public partial class UIGoldPPrompt
	{
		public const string Name = "UIGoldPPrompt";
		
		
		private UIGoldPPromptData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UIGoldPPromptData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGoldPPromptData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGoldPPromptData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
