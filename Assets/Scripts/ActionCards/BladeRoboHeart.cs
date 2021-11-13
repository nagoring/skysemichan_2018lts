using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
    public class BladeRoboHeart : ABase
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

            eActionCardName = EActionCardName.BladeRoboHeart;
            cardUsageText = $" [ブレードロボの心] \n 最大HP {maxhp}\n 攻撃 {atk}\n 速さ {agi}\n (ムキブツ)";
        }
	
        // Update is called once per frame
        void Update () {
		
        }
        public override string GetImageFilePath()
        {
            return "ActionCards/BladeRoboHeart";
        }
        public override string GetPrefabFilePath()
        {
            return "Prefabs/ActionCards/BladeRoboHeart";
        }
        public override EGroup GetGroup()
        {
            return EGroup.Mukibutu;
        }
        
    }
}