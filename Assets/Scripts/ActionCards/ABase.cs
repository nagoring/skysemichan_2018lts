using System.ComponentModel;
using Skysemi.With.Enum;
using UnityEngine;
using UnityEngine.UI;

namespace Skysemi.With.ActionCards
{
	public abstract class ABase : MonoBehaviour
	{
		public EActionCardName eActionCardName;
		public string cardUsageText;
		protected int lv;
		protected int maxhp;
		protected int spirit;
		protected int atk;
		protected int def;
		protected int str;
		protected int vit;
		protected int agi;
		public int MaxHp {get {return this.maxhp;}set{maxhp = value;}}
		public int Atk {get {return this.atk + this.str;}set{atk = value;}}
		public int Def {get {return this.def + this.vit;}set{def = value;}}
		public int Spirit {get {return this.spirit;}set{this.spirit = value;}}
		public int Agi {get {return this.agi;}set{this.agi = value;}}

		public EActionCardName GetEActionCardName()
		{
			return this.eActionCardName;
		}
		public string GetCardUsageText()
		{
			return this.cardUsageText;
		}
		
		public void SetEActionCardName(EActionCardName ineActionCardName)
		{
			this.eActionCardName = ineActionCardName;
		}

		public int GetAtk()
		{
			return Atk;
		}
		void Start()
		{
			eActionCardName = EActionCardName.None;
			cardUsageText = "";
			lv = 0;
			maxhp = 0;
			spirit = 0;
			atk = 0;
			def = 0;
			str = 0;
			vit = 0;
			agi = 0;
		}

		public abstract string GetImageFilePath();
		public abstract string GetPrefabFilePath();
		public abstract void Init();
	}
}