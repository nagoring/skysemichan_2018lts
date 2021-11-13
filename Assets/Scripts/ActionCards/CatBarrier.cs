using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
	public class CatBarrier : ActionCards.ABase
	{
		void Start ()
		{
			Init();
		}
		public override void Init()
		{
			lv = 0;
			atk = 0;
			def = 6;
			agi = 0;
			eActionCardName = EActionCardName.CatBarrier;
			cardUsageText = $" [猫バリア]\n 防御 {def}\n (メルヘン)\n 古代エジプト軍を無効化出来る";
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/CatBarrier";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/CatBarrier";
		}
		public override EGroup GetGroup()
		{
			return EGroup.Meruhen;
		}
	}
}