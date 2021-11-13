using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
    public class JusticeExecutorHeart : ABase
    {
        // Use this for initialization
        void Start ()
        {
            Init();
        }

        public override void Init()
        {
            lv = 0;
            atk = 4;
            def = 0;
            maxhp = 24;
            // maxhp = 1400;
            spirit = 0;
            agi = 5;

            eActionCardName = EActionCardName.JusticeExecutorHeart;
            cardUsageText = $" [正義の執行者の心] \n 最大HP {maxhp}\n 攻撃 {atk}\n 速さ {agi}\n (ナマモノ)";
        }
	
        // Update is called once per frame
        void Update () {
		
        }
        public override string GetImageFilePath()
        {
            return "ActionCards/JusticeExecutorHeart";
        }
        public override string GetPrefabFilePath()
        {
            return "Prefabs/ActionCards/JusticeExecutorHeart";
        }
        public override EGroup GetGroup()
        {
            return EGroup.Namamono;
        }
        
    }
}