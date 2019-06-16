using Skysemi.With.Enum;

namespace Skysemi.With.ActionCards
{
	public class Empty : ActionCards.ABase
	{
		// Use this for initialization
		void Start ()
		{
			Init();
		}

		public override void Init()
		{
			lv = 0;
			atk = 0;
			def = 0;
			spirit = 0;
			eActionCardName = EActionCardName.Empty;
			cardUsageText = $" [空白]";
			
		}
	
		// Update is called once per frame
		void Update () {
		
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/Empty";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/Empty";
		}
	}
}