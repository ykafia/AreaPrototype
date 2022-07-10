using System;
using Stride.Core;
using Stride.Rendering;
using Stride.Graphics;
using Stride.Shaders;
using Stride.Core.Mathematics;
using Buffer = Stride.Graphics.Buffer;

namespace AreaPrototype
{
    public static partial class LightQuadGroupKeys
    {
        public static readonly ValueParameterKey<QuadLightData> Lights = ParameterKeys.NewValue<QuadLightData>();
    }
}