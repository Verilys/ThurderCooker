// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace TravelStory
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    // Generate Id:869f6293-6366-402b-8efc-c79c4e9127e0
    public partial class UIKitTestPanel
    {
        
        public const string NAME = "UIKitTestPanel";
        
        private UIKitTestPanelData mPrivateData = null;
        
        public UIKitTestPanelData Data
        {
            get
            {
                return mData;
            }
        }
        
        UIKitTestPanelData mData
        {
            get
            {
                return mPrivateData ?? (mPrivateData = new UIKitTestPanelData());
            }
            set
            {
                mUIData = value;
                mPrivateData = value;
            }
        }
        
        protected override void ClearUIComponents()
        {
            mData = null;
        }
    }
}
