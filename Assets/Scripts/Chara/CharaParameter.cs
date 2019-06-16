using Skysemi.With.Enum;

namespace Skysemi.With.Chara
{
    public struct CharaParameter
    {
        public EChara  id;
        public string charaName;
        public int maxhp;
        public int tmpMaxHp;
        public int hp;
        public int atk;
        public int def;
        public int exp;
        public int lv;
        //筋力
        public int str;
        //丈夫さ/生命力
        public int vit;
        //気力
        public int spirit;
        //10固定
        public int maxspirit;
        //速さ
        public int agi;
        public EActionCardName[] actionCardNames;
        
        public int nextExp;
        public int progress;
    }
}