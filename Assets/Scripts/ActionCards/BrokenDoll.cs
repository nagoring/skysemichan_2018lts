using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
	public class BrokenDoll : ActionCards.ABase
	{
		void Start ()
		{
			Init();
		}
		public override void Init()
		{
			lv = 0;
			atk = 2;
			def = 0;
			agi = 0;
			eActionCardName = EActionCardName.BrokenDoll;
			cardUsageText = $" [壊れた人形]\n 攻撃 {atk}\n (メルヘン)\n メルヘン的な力で攻撃する";
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/BrokenDoll";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/BrokenDoll";
		}
		public override EGroup GetGroup()
		{
			return EGroup.Meruhen;
		}
	}
}