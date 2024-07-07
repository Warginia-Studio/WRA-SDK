using System;

namespace WRA.Utility.Diagnostics.Logs
{
    [Flags]
    public enum LogTag
    {
        all = 0,
        none = 1 << 0,
        ui = 1 << 1,
        panels = 1 << 2,
        zenject = 1 << 3,
        utility = 1 << 4,
        diagnostics = 1 << 5,
        logs = 1 << 6,
        warnings = 1 << 7,
        errors = 1 << 8,
        character = 1 << 9,
        player = 1 << 10,
        enemy = 1 << 11,
        game = 1 << 12,
        input = 1 << 13,
        audio = 1 << 14,
        animation = 1 << 15,
        camera = 1 << 16,
        effects = 1 << 17,
        events = 1 << 18,
    }
}