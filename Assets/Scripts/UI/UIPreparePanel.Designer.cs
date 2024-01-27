using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:e110b06d-04bc-4898-84ba-a40c59f9117e
	public partial class UIPreparePanel
	{
		public const string Name = "UIPreparePanel";
		[SerializeField]
		public TMPro.TextMeshProUGUI txt_money;
		[SerializeField]
		public TMPro.TextMeshProUGUI txtScores;
		[SerializeField]
		public UnityEngine.UI.Button actorsShopBtn;
		[SerializeField]
		public UnityEngine.UI.Button propsShopBtn;
		[SerializeField]
		public UnityEngine.UI.Button startPickBtn;
		[SerializeField]
		public RectTransform items;
		[SerializeField]
		public UnityEngine.UI.Button pBackBtn;
		[SerializeField]
		public RectTransform actors;
		[SerializeField]
		public UnityEngine.UI.Button aBackBtn;

		public GameObject goalPanel;
		public GameObject porpsPanel;
		public GameObject actorsPanel;
		
		public CharacterController controller;
		public GameObject currentActor;
		
		private UIPreparePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			txt_money = null;
			txtScores = null;
			actorsShopBtn = null;
			propsShopBtn = null;
			startPickBtn = null;
			items = null;
			pBackBtn = null;
			actors = null;
			aBackBtn = null;
			
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
