using Stride.Core.Mathematics;

namespace AreaPrototype
{
    public struct QuadLightData
    {
        public Vector3 PositionWS;
        float padding0;
        public Vector3 PlaneNormalWS;
        float padding1;
        public Vector3 Up;
        float padding2;
        public Vector3 Right;
        float padding3;
        public Color3 Color;
        public float Intensity;
        public Vector2 Extent;
    }
}