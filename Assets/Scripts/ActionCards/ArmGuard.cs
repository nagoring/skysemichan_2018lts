using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
	public class ArmGuard : ActionCards.ABase
	{
		void Start()
		{
			Init();
		}

		public override void Init()
		{
			lv = 0;
			atk = 0;
			def = 6;
			agi = 0;
			eActionCardName = EActionCardName.ArmGuard;
			cardUsageText = $" [腕防御]\n 防御 {def}";
		}

		public override string GetImageFilePath()
		{
			return "ActionCards/ArmGuard";
		}

		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/ArmGuard";
		}

		public override EGroup GetGroup()
		{
			return EGroup.Namamono;
		}
	}
}