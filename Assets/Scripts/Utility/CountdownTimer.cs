// using UnityEngine;
// using System.Collections;
// using System;
// using TMPro;
// namespace QFramework.ThunderCooker
// {
//     public class CountdownTimer: MonoBehaviour,IController
//     {
//         public TMP_Text txt_Time;
//         public float countdownTime = 100f;
//         private float timer;
//         private bool isTimeOver;
//         void Start()
//         {
//             timer = countdownTime;
//             isTimeOver = false;
//         }
//
//         void Update()
//         {
//             if (timer > 0f)
//             {
//                 timer -= Time.deltaTime;
//                 string formattedTime = FormatTime(timer);
//                 txt_Time.text = formattedTime;
//             }
//             else
//             {
//                 if (!isTimeOver)
//                 {
//                     this.SendCommand<TimeOverCommand>();
//                     txt_Time.text = " ";
//                     isTimeOver = true;
//                 }
//
//             }
//             string FormatTime(float timeInSeconds)
//             {
//                 int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
//                 int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
//                 return string.Format("{0:00}:{1:00}", minutes, seconds);
//             }
//         }
//         public IArchitecture GetArchitecture()
//         {
//             return GameApp.Interface;
//         }
//     }
//     
// }
