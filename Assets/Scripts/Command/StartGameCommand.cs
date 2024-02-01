using UnityEngine.SceneManagement;
namespace QFramework.ThunderCooker
{
    public class StartGameCommand : AbstractCommand
    {
        public class GameStartEvent { }
        protected override void OnExecute()
        {
            // 重置数据
            var gameModel = this.GetModel<DataModel>();
            gameModel.Days = 3;
            gameModel.Coins = 50;
            gameModel.Scores = 0;

            gameModel.isWin = false;
            gameModel.isCurtainOpen = true;
            
            gameModel.actorShopList.Add(new DataModel.Actor("Keyboard","UI_Keyboard",10));
            gameModel.actorShopList.Add(new DataModel.Actor("Cooker","UI_Cooker",10));
            gameModel.actorShopList.Add(new DataModel.Actor("Dog","UI_Dog",10));
            gameModel.actorShopList.Add(new DataModel.Actor("Eggplant","UI_Eggplant",10));
            gameModel.actorShopList.Add(new DataModel.Actor("Tomato","UI_Tomato",10));
            gameModel.actorShopList.Add(new DataModel.Actor("Giraffe","UI_Giraffe",10));
      
            gameModel.actorPurchasedList.Add(new DataModel.Actor("Bin","UI_Bin",10));

            gameModel.isCurtainOpen = true;
            SceneManager.LoadScene("Level 1");
            this.SendEvent<GameStartEvent>();
            
        }
    }
    
}


