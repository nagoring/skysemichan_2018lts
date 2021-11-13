using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
	public class HandGuard : ActionCards.ABase
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
			cardUsageText = $" [手防御]\n 防御 {def}\n (ナマモノ)";
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/HandGuard";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/HandGuard";
		}
		public override EGroup GetGroup()
		{
			return EGroup.Namamono;
		}
	}
}