// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using QFramework;
// using Random = UnityEngine.Random;
//
// namespace QFramework.ThunderCooker
// {
// 	public partial class CharacterSpineController : ViewController
// 	{
// 		//DataModel mModel = this.GetModel<DataModel>();
// 		private void Awake()
// 		{
// 			foreach (var spineActor in spineCharacters)
//             {
//              	spineActor.SetActive(false);
//             }
// 		}
// 		
// 		private List<GameObject> tempList= new List<GameObject>(); 
// 		private int order = 0;
// 		void Start()
// 		{
// 			foreach (var item in usingItems)
// 			{
// 				item.SetActive(false);
// 			}
// 			var findObj = GameObject.Find("CharacterController");
// 			if (findObj == null)
// 			{
// 				Debug.LogWarning("没找到！");
// 			}
// 			else
// 			{
// 				CharacterController controller = findObj.GetComponent<CharacterController>();
//             	// foreach (var actor in )
//             	// {
//             	// 	foreach (var spineActor in spineCharacters)
//             	// 	{
// 	            //         if (actor.name == "UI_" + spineActor.name)
//             	// 		{
// 	            //             Debug.Log("开启"+spineActor.name);
//             	// 			spineActor.SetActive(true);
//             	// 		}
//             	// 	}
//             	// }	
//                 
// 			}
// 			/*
// 			int random1 = RandomInt(0, 8);
// 			int random2 = RandomInt(0, 8, random1);
// 			int random3 = RandomInt(0, 8, random1, random2);
// 			
// 			int random4 = RandomInt(0, 6);
// 			int random5 = RandomInt(0, 6, random4);
// 			int random6 = RandomInt(0, 6, random4, random5);
// 			usingItems[random1].SetActive(true);
// 			usingItems[random2].SetActive(true);
// 			usingItems[random3].SetActive(true);
// 			//spineCharacters[random4].GetComponent<BasicPlatformerController>().isControlled = true;
// 				spineCharacters[random4].SetActive(true);
// 			spineCharacters[random5].SetActive(true);
// 			spineCharacters[random6].SetActive(true);
// 			 
// 			tempList.Add(spineCharacters[random4]);
// 			tempList.Add(spineCharacters[random5]);
// 			tempList.Add(spineCharacters[random6]);
// 			*/
// 			//RandomItem();
// 			
// 		}
// 		
// 		private void Update()
// 		{
// 			// spineCharacters[num1].GetComponent<BasicPlatformerController>().isControlled = false;
// 			// spineCharacters[num2].GetComponent<BasicPlatformerController>().isControlled = false;
// 			// spineCharacters[num3].GetComponent<BasicPlatformerController>().isControlled = false;
// 			//  if (Input.GetKey(KeyCode.E))
// 			//  {
// 			//  	order = (order + 1) % 2;
// 			//  		CloseAll();
// 			//  		tempList[order].GetComponent<BasicPlatformerController>().isControlled = true;
// 			// }
// 		}
//
// 		public void CloseAll()
// 		{
// 			foreach (var obj in tempList)
// 			{
// 				obj.GetComponent<BasicPlatformerController>().isControlled = false;
// 			}
// 		}
// 		public void RandomItem()
// 		{
// 			
// 		}
// 		// 生成指定范围内不重复的随机整数
// 		int RandomInt(int min, int max, params int[] exclude)
// 		{
// 			int randomValue;
// 			do
// 			{
// 				randomValue = Random.Range(min, max + 1);
// 			} while (ArrayContains(exclude, randomValue));
//
// 			return randomValue;
// 		}
//
// 		// 检查数组中是否包含指定的值
// 		bool ArrayContains(int[] array, int value)
// 		{
// 			foreach (int item in array)
// 			{
// 				if (item == value)
// 				{
// 					return true;
// 				}
// 			}
// 			return false;
// 		}
// 	}
// }
