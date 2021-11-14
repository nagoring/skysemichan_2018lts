using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
	public class SChanCard1 : ActionCards.ABase
	{
		void Start ()
		{
			Init();
		}
		public override void Init()
		{
			lv = 0;
			atk = 4;
			def = 0;
			agi = 0;
			eActionCardName = EActionCardName.SChanCard1;
			cardUsageText = $" [青髪メイド少女]\n 攻撃 {atk}\n  (メルヘン)\n ";
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/SChanCard1";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/SChanCard1";
		}
		public override EGroup GetGroup()
		{
			return EGroup.Meruhen;
		}
	}
}