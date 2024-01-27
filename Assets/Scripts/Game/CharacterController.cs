using System.Runtime.CompilerServices;
using UnityEngine;
using QFramework;
using UnityEngine.UI;
namespace QFramework.ThunderCooker
{
	public partial class CharacterController : ViewController, IController
	{
		private static CharacterController instance;
		private DataModel mModel;
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}
		void Start()
		{
			mModel = this.GetModel<DataModel>();
			InitializeShop();
		}
		void InitializeShop()
		{
			// for (int i = 0; i < shopCharacters.Count; i++)
			// {
			// 	shopCharactersBtn[i] = shopCharacters[i].GetComponent<UnityEngine.UI.Button>();
			// }
		}
		// 购买角色的逻辑
		public void PurchaseCharacter(GameObject characterPrefab)
		{
			Debug.Log("买");
			characterPrefab.GetComponent<UIActorProperty>().isPurchase = true;
			characterPrefab.GetComponent<Button>().interactable = false;
			// 将角色从商店移动到已购买库
			shopCharacters.Remove(characterPrefab);
			purchasedCharacters.Add(characterPrefab);
		}
		
		public void AddToBackpack(GameObject characterPrefab)
		{
			// 将角色添加到背包的逻辑
			// 检查背包是否已满
			// 如果未满，将角色从已购买库移动到背包
			if (backpackCharacters.Count == 3)
			{
				Debug.Log("背包满了");
			}
			else
			{
				characterPrefab.GetComponent<UIActorProperty>().isPicked = true;
				characterPrefab.GetComponent<Button>().interactable = false;
				purchasedCharacters.Remove(characterPrefab);
				backpackCharacters.Add(characterPrefab);				
			}

		}

		public void RemoveFromBackpack(DataModel.Actor characterPrefab)
		{
			// 将角色从背包中移除的逻辑
			// 将角色从背包列表中移除
		}

		public void UpdateUI()
		{
			Debug.Log("更新UI");
			// foreach (var actor in shopCharacters)
			// {
			// 	if (actor.GetComponent<UIActorProperty>().isPurchase)
			// 	{
			// 		actor.GetComponent<Button>().interactable = false;
			// 	}
			// }
		}
		public IArchitecture GetArchitecture()
		{
			return GameApp.Interface;
		}
	}
}
