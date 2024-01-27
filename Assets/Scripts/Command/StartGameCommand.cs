using UnityEngine.SceneManagement;
namespace QFramework.ThunderCooker
{
    public class StartGameCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            // 重置数据
            //var gameModel = this.GetModel<IGameModel>();
            var gameModel = this.GetModel<DataModel>();
            gameModel.Days = 3;
            gameModel.Coins = 0;
            gameModel.Scores = 0;
            SceneManager.LoadScene("Prepare");
            this.SendEvent<GameStartEvent>();
            
        }
    }
    
}


