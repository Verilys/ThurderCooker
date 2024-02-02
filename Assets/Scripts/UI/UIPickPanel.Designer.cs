using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.ThunderCooker
{
	// Generate Id:8123ab2f-d5be-4bb0-9ed5-af4712dc6005
	public partial class UIPickPanel
	{
		public const string Name = "UIPickPanel";
		
		[SerializeField]
		public RectTransform aContent;
		[SerializeField]
		public RectTransform pContent;
		[SerializeField]
		public UnityEngine.UI.Button nextBtn;
		
		public CharacterController controller;
		public ObjectsController objContrller;
		public GameObject currentActor;
		
		private UIPickPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			aContent = null;
			pContent = null;
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
