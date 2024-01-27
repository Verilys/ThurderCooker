using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:74943d67-a212-4ec7-bf1d-518d0df5925c
	public partial class UIPreparePanel
	{
		public const string Name = "UIPreparePanel";
		
		[SerializeField]
		public TMPro.TextMeshProUGUI txtScores;
		[SerializeField]
		public UnityEngine.UI.Button actorsShopBtn;
		[SerializeField]
		public UnityEngine.UI.Button propsShopBtn;
		[SerializeField]
		public UnityEngine.UI.Button startPickBtn;
		[SerializeField]
		public UnityEngine.UI.Button pBackBtn;
		[SerializeField]
		public UnityEngine.UI.Button aBackBtn;
		
		public GameObject goalPanel;
		public GameObject porpsPanel;
		public GameObject actorsPanel;
		
		private UIPreparePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			txtScores = null;
			actorsShopBtn = null;
			propsShopBtn = null;
			startPickBtn = null;
			pBackBtn = null;
			aBackBtn = null;

			//goalPanel.DestroySelf();
			
			mData = null;
		}
		
		public UIPreparePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIPreparePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIPreparePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
