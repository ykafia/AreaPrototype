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
    [DataContract("LightArea")]
    [Display("Area")]
    public class LightArea : DirectLightBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LightArea"/> class.
        /// </summary>
        public LightArea()
        {
            Range = 1.0f;
            // Shadow = new LightAreaShadowMap()
            // {
            //     Size = LightShadowMapSize.Small,
            //     Type = LightAreaShadowMapType.CubeMap,
            // };
        }
        // public Texture Texture;
        public float Intensity {get;set;}
        public bool TwoSided {get;set;}

        public Vector2 Scale {get;set;} = Vector2.One;
        public float Range {get;set;}

        private Vector3[] Square => new Vector3[]{
            new(Scale.X,Scale.Y,0f),
            new(Scale.X,-Scale.Y,0f),
            new(-Scale.X,-Scale.Y,0f),
            new(-Scale.X,Scale.Y,0f)
        };

        public override bool HasBoundingBox
        {
            get
            {
                return true;
            }
        }

        public override bool Update(RenderLight light)
        {
            Range = Math.Max(0.001f, Range);
            Scale = new(Math.Max(0.001f, Scale.X), Math.Max(0.001f, Scale.Y));
            return true;
        }

        public override BoundingBox ComputeBounds(Vector3 positionWS, Vector3 directionWS)
        {
            // return new BoundingBox(positionWS - Radius, positionWS + Radius);
            var min = new Vector3(-Scale.X/2, -Scale.Y/2, TwoSided ? -Range : 0);
            var max = new Vector3(Scale/2,Range);
            var rotation = Quaternion.BetweenDirections(-Vector3.UnitZ, directionWS);            
            rotation.Rotate(ref min);
            rotation.Rotate(ref max);
            return new(min + positionWS, max + positionWS);
        }
       
        public override float ComputeScreenCoverage(RenderView renderView, Vector3 position, Vector3 direction)
        {
            var min = new Vector3(-Scale.X/2, -Scale.Y/2, TwoSided ? -Range : 0);
            var max = new Vector3(Scale/2,Range);
            var rotation = Quaternion.BetweenDirections(-Vector3.UnitZ, direction);            
            
            var points = Square.Select(x =>{var tmp = x; rotation.Rotate(ref tmp); return tmp;}).Select(x => Vector3.Transform(x, renderView.ViewProjection));
            var height = Math.Abs(points.Max(v => v.X)) + Math.Abs(points.Min(v => v.X));
            var width = Math.Abs(points.Max(v => v.Y)) + Math.Abs(points.Min(v => v.Y));
            return Math.Max(height,width);
        }
    }
}