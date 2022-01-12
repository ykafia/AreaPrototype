using Stride.Core.Mathematics;

namespace AreaPrototype
{
    public struct DiscLightData
    {
        public Vector3 PositionWS;
        float padding0;
        public Vector3 PlaneNormalWS;
        float padding1;
        public Color3 Color;
        public float Range;
        public float Radius;
        public float Intensity;
    }
}