using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
	public class ReafBarrier : ActionCards.ABase
	{
		void Start ()
		{
			Init();
		}
		public override void Init()
		{
			lv = 0;
			atk = 0;
			def = 2;
			agi = 0;
			eActionCardName = EActionCardName.HandGuard;
			cardUsageText = $" [葉っぱバリア]\n 防御 {def}\n (メルヘン)";
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/ReafBarrier";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/ReafBarrier";
		}
		public override EGroup GetGroup()
		{
			return EGroup.Meruhen;
		}
	}
}