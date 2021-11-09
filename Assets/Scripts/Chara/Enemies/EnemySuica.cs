using Skysemi.With.Enum;

namespace Skysemi.With.Chara.Enemies
{
    public class EnemySuica : Enemy
    {
        void Awake()
        {
            Init();
        }

        public override void Init()
        {
            this.Id = EChara.Suica;
            this.CharaName = "スイカ";
            this.MaxHp = 110;
            this.Hp = MaxHp;
            this.Atk = 20;
            this.Def = 3;
            this.Spirit = 1;
            this.MaxSpirit = 1;
            this.exp = 40;
            this.msg = "シャリシャリ！！食えたらおいしいだろう？シャリシャリ！！";
            //msgDamageAfterDict.Add(id)
            this.msgDamageAfterList.Add("シャリシャリ！お前にはスイカの皮がおにあいさ！");
            this.msgDamageAfterList.Add("中身が食われる日が来るかもしれないな！シャリシャリするといいさ！");
        }
        void OnEnable()
        {
            Init();
        }
        public override string GetImageFilePath()
        {
            return "Enemies/スイカ";

        }
        public override string GetPrefabFilePath()
        {
            throw new System.NotImplementedException();
        }
        
    }
}