using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
	public class CarrotHeart : ActionCards.ABase
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
			def = 2;
			maxhp = 10;
			spirit = 0;
			agi = 6;

			eActionCardName = EActionCardName.CarrotHeart;
			cardUsageText = $" [人参の心] \n 最大HP {maxhp}\n 攻撃 {atk}\n 速さ {agi}\n (ナマモノ)";
		}
	
		// Update is called once per frame
		void Update () {
		
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/CarrotHeart";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/CarrotHeart";
		}
		public override EGroup GetGroup()
		{
			return EGroup.Namamono;
		}
	}
}