using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.ThunderCooker
{
    public class ObjectsController : MonoBehaviour, IController
    {
        public GameObject curtain;
        public Slider favorUI;
        
        private float decreaseRate = 0.05f;
        
        public TMP_Text timerText;
        private float countdownTime = 120f; // 初始倒计时时间，单位为秒
        
        void Start()
        {
            var mModel = this.GetModel<DataModel>();
            
            favorUI.value = mModel.audience.favorabilty;
            
            this.RegisterEvent<CurtainEvent>(e =>
            {
                if (mModel.isCurtainOpen)
                {
                    curtain.SetActive(true);    
                }
                else
                {
                    curtain.SetActive(false); 
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
            this.RegisterEvent<StartPerformEvent>(e =>
            {
                //观众喜好值下降
                StartCoroutine(FavorChange(mModel));
               
                //时间倒计时
                StartCoroutine(StartCountdown());
            }).UnRegisterWhenGameObjectDestroyed(gameObject);


            
        }
        

        IEnumerator FavorChange(DataModel model)
        {
            while (model.audience.favorabilty > 0)
            {
                model.audience.favorabilty -= decreaseRate * Time.deltaTime;
                model.audience.favorabilty = Mathf.Clamp01(model.audience.favorabilty);
                //Debug.Log("好感值：" + favor);
                favorUI.value = model.audience.favorabilty;
                yield return null;
            }
        }
        IEnumerator StartCountdown()
        {
            while (countdownTime > 0f)
            {
                // 更新显示的分钟和秒数
                int minutes = Mathf.FloorToInt(countdownTime / 60f);
                int seconds = Mathf.FloorToInt(countdownTime % 60f);

                // 格式化文本并更新显示
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                // 减少倒计时时间
                countdownTime -= Time.deltaTime;

                // 等待一帧
                yield return null;
            }

            // 倒计时结束时的处理
            timerText.text = "00:00";
            Debug.Log("Countdown Finished");
            this.SendCommand<TimeOverCommand>();
        }

        public IArchitecture GetArchitecture()
        {
            return GameApp.Interface;
        }
    }    

}

