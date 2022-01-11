using System;
using Stride.Rendering;
using Stride.Graphics;
using Stride.Core.Mathematics;
using Stride.Rendering.Lights;
using Stride.Core;
using System.ComponentModel;
using System.Linq;

namespace AreaPrototype
{
    /// <summary>
    /// An Area light.
    /// </summary>
    [DataContract("LightSphere")]
    [Display("Sphere")]
    public class LightSphere : DirectLightBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LightSphere"/> class.
        /// </summary>
        public LightSphere()
        {
            Radius = 1.0f;
            Shadow = new LightSphereShadowMap()
            {
                Size = LightShadowMapSize.Small
            };
        }
        // public Texture Texture;
        public float Intensity {get;set;}
        public bool TwoSided {get;set;}
        public float Radius {get;set;}

        public override bool HasBoundingBox
        {
            get
            {
                return true;
            }
        }

        public override bool Update(RenderLight light)
        {
            Radius = Math.Max(0.01f, Radius);
            return true;
        }

        public override BoundingBox ComputeBounds(Vector3 positionWS, Vector3 directionWS)
        {
            // return new BoundingBox(positionWS - Radius, positionWS + Radius);
            return new(positionWS - Radius , positionWS + Radius);
        }
       
        public override float ComputeScreenCoverage(RenderView renderView, Vector3 position, Vector3 direction)
        {
            var targetPosition = new Vector4(position, 1.0f);
            Vector4.Transform(ref targetPosition, ref renderView.ViewProjection, out Vector4 projectedTarget);

            var d = Math.Abs(projectedTarget.W) + 0.00001f;
            var r = Radius;

            // Handle correctly the case where the eye is inside the sphere
            if (d < r)
                return Math.Max(renderView.ViewSize.X, renderView.ViewSize.Y);

            var coTanFovBy2 = renderView.Projection.M22;
            var pr = r * coTanFovBy2 / (Math.Sqrt(d * d - r * r) + 0.00001f);

            // Size on screen
            return (float)pr * Math.Max(renderView.ViewSize.X, renderView.ViewSize.Y);
        }
    }
}