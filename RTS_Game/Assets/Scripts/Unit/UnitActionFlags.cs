using System;

[Flags]
public enum UnitActionFlags
{
    None = 0,
    Move = 1,
    Patrol = 2,
    Attack = 4,
    GatherResource = 8,
    Build = 16,
    Idle = 32,
    Cancel = 64,
}