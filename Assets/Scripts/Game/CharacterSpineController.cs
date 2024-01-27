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
			CharacterController controller = findObj.GetComponent<CharacterController>();
			foreach (var actor in controller.backpackCharacters)
			{
				foreach (var spineActor in SpineCharacters)
				{
					if (actor.name == spineActor.name)
					{
						spineActor.SetActive(true);
					}
				}
			}
		}
	}
}
