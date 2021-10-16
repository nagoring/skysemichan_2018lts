using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Chara.Enemies
{
    public class EnemyKyuuri : Enemy {
        void Awake()
        {
            Init();
        }

        void Init()
        {
            this.id = EChara.Kyuuri;
            this.CharaName = "きゅうり";
            this.MaxHp = 10;
            this.Hp = MaxHp;
            this.exp =5;
            this.Atk = 8;
            this.Def = 0;
            this.Agi = 0;
            this.Spirit = 1;
            this.MaxSpirit = 1;
            this.msg = "うひひ、わたしを食べれるかな";
            //msgDamageAfterDict.Add(id)

            this.msgDamageAfterList = new List<string>();
            this.msgDamageAfterList.Add("まだまだだねぇ");
            this.msgDamageAfterList.Add("うひひ、きゅうりのつけものになりそうなよかん");
        }
        void OnEnable()
        {
            Init();
        }
        void Start() {
        }

        // Update is called once per frame
        void Update () {
		
        }

        public override string GetImageFilePath()
        {
            return "Enemies/kyuuri";
        }

        public override string GetPrefabFilePath()
        {
            throw new System.NotImplementedException();
        }
    }

}
