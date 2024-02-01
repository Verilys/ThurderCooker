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
		private DataModel mModel;
		
		private int order = 0;

		private bool isDoll = false;

		void Start()
		{
			mModel = this.GetModel<DataModel>();
		}

		void Update()
		{
			//这里需要判断一下，只有非Doll的时候才能切换
			if (Input.GetKey(KeyCode.E) && isDoll)
			{
				packCharacters[order].GetComponent<BasicPlatformerController>().isControlled = false;
				order = (order + 1) % packCharacters.Count;
				packCharacters[order].GetComponent<BasicPlatformerController>().isControlled = true;
			}
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
				
			// }

		}

		public void RemoveFromBackpack(DataModel.Actor characterPrefab)
		{
			// 将角色从背包中移除的逻辑
			// 将角色从背包列表中移除
		}

		public void UpdateUI(){}
		public IArchitecture GetArchitecture()
		{
			return GameApp.Interface;
		}
	}
}
