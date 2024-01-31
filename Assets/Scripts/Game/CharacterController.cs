using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using QFramework;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
namespace QFramework.ThunderCooker
{
	public partial class CharacterController : ViewController, IController
	{
		//private static CharacterController instance;
		private DataModel mModel;
		
		private int order = 0;

		private bool isPress = false;
		// private void Awake()
		// {
		// 	if (instance == null)
		// 	{
		// 		instance = this;
		// 		DontDestroyOnLoad(gameObject);
		// 	}
		// 	else
		// 	{
		// 		Destroy(gameObject);
		// 	}
		// }
		void Start()
		{
			mModel = this.GetModel<DataModel>();
			// foreach (var spineActor in spineCharacters)
			// {
			// 	spineActor.SetActive(false);
			// }
			
		}

		void Update()
		{
			if (Input.GetKey(KeyCode.E) && !isPress)
			{
				Debug.Log(isPress);
				packCharacters[order].GetComponent<BasicPlatformerController>().isControlled = false;
				order = (order + 1) % packCharacters.Count;
				packCharacters[order].GetComponent<BasicPlatformerController>().isControlled = true;
				isPress = true;
				Invoke("DelayedAction", 1f);
				
			}
		}
		
		void DelayedAction()
		{
			isPress = false;
		}
		// 购买角色的逻辑
		public void PurchaseCharacter(DataModel.Actor currentActor)
		{
			// 将角色从商店移动到已购买库
			currentActor.isPurchased = true;
			mModel.actorShopList.Remove(currentActor);
			mModel.actorPurchasedList.Add(currentActor);
			Debug.Log("买");
		}
		
		public void AddToBackpack(GameObject characterPrefab)
		{
			// 将角色添加到背包的逻辑
			// 检查背包是否已满
			// 如果未满，将角色从已购买库移动到背包
			// if (mModel..Count == 3)
			// {
			// 	Debug.Log("背包满了");
			// }
			// else
			// {
			// 	characterPrefab.GetComponent<UIActorProperty>().isPicked = true;
			// 	characterPrefab.GetComponent<Button>().interactable = false;
			// 	Debug.Log(characterPrefab.name);
			// 	ui_purchasedCharacters.Remove(characterPrefab);
			// 	ui_backpackCharacters.Add(characterPrefab);				
			// }

		}

		public void RemoveFromBackpack(DataModel.Actor characterPrefab)
		{
			// 将角色从背包中移除的逻辑
			// 将角色从背包列表中移除
		}

		public void UpdateUI()
		{
			Debug.Log("更新UI");
			foreach (var actor in ui_Characters)
			{
				foreach (var VARIABLE in mModel.actorShopList)
				{
					
				}
				
			}
		}
		public IArchitecture GetArchitecture()
		{
			return GameApp.Interface;
		}
	}
}
