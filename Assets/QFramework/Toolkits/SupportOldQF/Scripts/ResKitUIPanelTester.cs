using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{
    public class ResKitUIPanelTester : MonoBehaviour
    {
 
            /// <summary>
            /// 页面的名字
            /// </summary>
            public string PanelName;

            /// <summary>
            /// 层级名字
            /// </summary>
            public UILevel Level;

            [SerializeField] private List<UIPanelTesterInfo> mOtherPanels;

            private void Awake()
            {
                ResKit.Init();
            }

            private IEnumerator Start()
            {
                yield return new WaitForSeconds(0.2f);
			    UIKit.Root.SetResolution(1920,1080,0);
                UIKit.OpenPanel(PanelName, Level);
                
                mOtherPanels.ForEach(panelTesterInfo => { UIKit.OpenPanel(panelTesterInfo.PanelName, panelTesterInfo.Level); });
            }
    }
}