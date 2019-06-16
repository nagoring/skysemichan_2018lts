namespace Skysemi.With.Enum
{
    public enum EGameProgress
    {
        ZERO = 0,
        GAME_START = 1,
        SHOW_STAGE_1 = 1 << 1,
        SHOW_STAGE_2 = 1 << 2,
        SHOW_STAGE_3 = 1 << 3,
        SHOW_STAGE_4 = 1 << 4,
        SHOW_OTHER_STAGE_1 = 1 << 5,
        SHOW_OTHER_STAGE_GEDOUGARI = 1 << 6,
    }
}

