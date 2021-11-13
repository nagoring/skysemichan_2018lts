using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
	public class Witch : ActionCards.ABase
	{
		void Start ()
		{
			Init();
		}
		public override void Init()
		{
			lv = 0;
			atk = 6;
			def = 2;
			agi = -2;
			eActionCardName = EActionCardName.BrokenDoll;
			cardUsageText = $" [魔法使い]\n 攻撃 {atk}\n 防御 {def}\n 速さ {agi}\n (メルヘン)\n ";
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