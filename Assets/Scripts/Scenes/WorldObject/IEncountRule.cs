using Skysemi.With.Enum;

namespace Skysemi.With.Scenes.WorldObject
{
    public interface IEncountRule
    {
        void Run();
        EWorldMode GetWorldMode();
        bool IsBoss();
        bool IsEncount();
        void OutputEnemy(ISetUpEnemy iSetUpEnemy);
        void ShuffleRandomEncount();
    }
}