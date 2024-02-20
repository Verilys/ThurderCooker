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
		
		public void AddToBackpack(DataModel.Actor currentActor)
		{
			//将角色添加到背包的逻辑
			//检查背包是否已满
			//如果未满，将角色从已购买库移动到背包
			if (mModel.actorPickList.Count == 3)
			{
				Debug.Log("背包满了");
			}
			else
			{
				mModel.actorPurchasedList.Remove(currentActor);
				mModel.actorPickList.Add(currentActor);
				Debug.Log("添加角色");
			}

		}

		public void RemoveFromBackpack(DataModel.Actor currentActor)
		{
			// 将角色从背包列表中移除
			if (mModel.actorPickList != null)
			{
				mModel.actorPurchasedList.Remove(currentActor);
				mModel.actorPickList.Add(currentActor);
				Debug.Log("移除角色");				
			}

		}

		public void UpdateUI(){}
		public IArchitecture GetArchitecture()
		{
			return GameApp.Interface;
		}
	}
}
