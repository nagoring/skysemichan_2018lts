using Skysemi.With.Core;
using Skysemi.With.Events;
using UnityEngine;
using UnityEngine.UI;

namespace StatusUI
{
    public class EnemyStatusWindow : AppMonoBehaviour
    {
//        private const string PrefabPath = "Prefabs/StatusUI/EnemyStatusWindow";
        
        public Text Name { get; set; }
        public Text Hp { get; set; }
        public Text Spirit { get; set; }
        public Text Atk { get; set; }
        public Text Def { get; set; }
        
        
        
        
//        public static EnemyStatusWindow CreateEnemyStatusWindowInCanvasUI(Canvas canvasUI)
//        {
//            GameObject obj = (GameObject)Resources.Load (PrefabPath);
//            obj.SetActive(true);
//            // プレハブを元にCardBoardを生成して、CanvasUIの子供にする
//            GameObject instance = (GameObject)Instantiate(obj,Vector2.zero,Quaternion.identity);
//            instance.transform.parent = canvasUI.transform;
//            instance.transform.localScale = new Vector3(1,1,1);
//            instance.transform.localPosition = new Vector3(399,-70, 0);
//            EnemyStatusWindow enemyStatusWindow = instance.GetComponent<EnemyStatusWindow>();
//            enemyStatusWindow.Init();
//            return enemyStatusWindow;
//        }
        
        public void Init()
        {
            Name = transform.Find("TextEnemyName").GetComponent<Text>();
            Hp = transform.Find("TextEnemyHp").GetComponent<Text>();
            Spirit = transform.Find("TextEnemySpirit").GetComponent<Text>();
            Atk = transform.Find("TextEnemyAtk").GetComponent<Text>();
            Def = transform.Find("TextEnemyDef").GetComponent<Text>();
        }
        

        public void SyncEnemyStatusReceiver(BaseEventArgs e)
        {
            var args = (SyncStatusEnemyEventArgs)e.GetObject();
            int hp = args.CharaParameter.hp;
            int spirit = args.CharaParameter.spirit;
            int atk = args.CharaParameter.atk;
            int def = args.CharaParameter.def;
            
            Hp.text = args.CharaParameter.hp.ToString();
            Spirit.text = args.CharaParameter.spirit.ToString();
            Atk.text = args.CharaParameter.atk.ToString();
            Def.text = args.CharaParameter.def.ToString();
            
            
        }
        
    }
        
}