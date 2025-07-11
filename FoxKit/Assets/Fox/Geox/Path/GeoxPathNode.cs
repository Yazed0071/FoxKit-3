﻿using System;
using System.ComponentModel;

namespace Fox.Geox
{
    public partial class GeoxPathNode : Fox.Graphx.GraphxSpatialGraphDataNode
    {
        [Flags]
        public enum Tags : uint
        {
            [Description("Edge")]
            Edge = 0x1,
            [Description("Cover")]
            Cover = 0x2,
            [Description("BEHIND_LOOK_IN")]
            BEHIND_LOOK_IN = 0x4,
            [Description("CHANGE_TO_60")]
            CHANGE_TO_60 = 0x8,

            [Description("NoTurn")]
            NoTurn = 0x10,
            [Description("BEHIND_STOP")]
            BEHIND_STOP = 0x20,
            [Description("NoOut")]
            NoOut = 0x40,
            [Description("NoStart")]
            NoStart = 0x80,

            [Description("EludeToElude")]
            EludeToElude = 0x100,
        };
    }
}
