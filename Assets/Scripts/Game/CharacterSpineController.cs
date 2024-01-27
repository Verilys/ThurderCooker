using UnityEngine;
using QFramework;

namespace QFramework.ThunderCooker
{
	public partial class CharacterSpineController : ViewController
	{
		void Start()
		{
			foreach (var spineActor in SpineCharacters)
			{
				spineActor.SetActive(false);
			}
			
			var findObj = GameObject.Find("CharacterController");
			if (findObj == null)
			{
				Debug.LogWarning("没找到！");
			}
			else
			{
				CharacterController controller = findObj.GetComponent<CharacterController>();
            	foreach (var actor in controller.backpackCharacters)
            	{
            		foreach (var spineActor in SpineCharacters)
            		{
            			if (actor.name == "UI_" + spineActor.name)
            			{
	                        Debug.Log("开启玩家");
            				spineActor.SetActive(true);
            			}
            		}
            	}	
			}
			
		}
	}
}
