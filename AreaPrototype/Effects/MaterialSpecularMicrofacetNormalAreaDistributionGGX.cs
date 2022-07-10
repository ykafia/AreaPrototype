// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Stride.Core;
using Stride.Rendering.Materials;
using Stride.Shaders;

namespace AreaPrototype
{
    /// <summary>
    /// The GGX Normal Distribution.
    /// </summary>
    [DataContract("MaterialSpecularMicrofacetNormalAreaDistributionGGX")]
    [Display("AreaGGX")]
    public class MaterialSpecularMicrofacetNormalAreaDistributionGGX : IMaterialSpecularMicrofacetNormalDistributionFunction
    {
        public ShaderSource Generate(MaterialGeneratorContext context)
        {
            return new ShaderClassSource("MaterialSpecularMicrofacetNormalAreaDistributionGGX");
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is MaterialSpecularMicrofacetNormalDistributionGGX;
        }

        public override int GetHashCode()
        {
            return typeof(MaterialSpecularMicrofacetNormalDistributionGGX).GetHashCode();
        }
    }
}
