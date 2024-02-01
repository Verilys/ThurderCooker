using UnityEngine;

namespace QFramework.ThunderCooker
{
    public class ObjectsController : MonoBehaviour, IController
    {
        public GameObject curtain;
        void Start()
        {
            var mModel = this.GetModel<DataModel>();
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
        }

        
        
        public IArchitecture GetArchitecture()
        {
            return GameApp.Interface;
        }
    }    

}

