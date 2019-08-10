using Skysemi.With.Enum;

namespace Skysemi.With.Scenes.WorldObject
{
    public interface IGoFrontStateChangeParameter
    {
        void SetWorldMode(EWorldMode eWorldMode);
        EWorldMode GetWorldMode();
//        int GetRandomEncount();
//        int DecrementRandomEncount();
        bool IsBoss();
        void SetIsBoss(bool isBoss);
    }
}