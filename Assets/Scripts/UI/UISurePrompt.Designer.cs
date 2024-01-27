using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:c2604f50-dfb0-4dda-be0d-bd43b92bb910
	public partial class UISurePrompt
	{
		public const string Name = "UISurePrompt";
		
		
		private UISurePromptData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UISurePromptData Data
		{
			get
			{
				return mData;
			}
		}
		
		UISurePromptData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UISurePromptData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
