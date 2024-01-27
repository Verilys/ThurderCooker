using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:b121ae63-c8ef-49c5-b8bb-3067b65d38ae
	public partial class UISurePrompt
	{
		public const string Name = "UISurePrompt";
		
		[SerializeField]
		public UnityEngine.UI.Button yesBtn;
		[SerializeField]
		public UnityEngine.UI.Button noBtn;

		public GameObject preparePanel;
		private UISurePromptData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			yesBtn = null;
			noBtn = null;
			
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
