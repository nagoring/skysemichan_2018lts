using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
	public class Shoes : ActionCards.ABase
	{
		void Start ()
		{
			Init();
		}
		public override void Init()
		{
			lv = 0;
			atk = 0;
			def = 0;
			agi = 5;
			eActionCardName = EActionCardName.Shoes;
			cardUsageText = $" [靴]\n 速さ {agi}";
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/Shoes";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/Shoes";
		}
		public override EGroup GetGroup()
		{
			return EGroup.Mukibutu;
		}

	}
}