using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace AreaPrototype
{
    public class MoveLights : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        
        public Vector3 InitPos = Vector3.Zero;

        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            Entity.Transform.Position.Y = InitPos.Y + (float)Math.Abs(Math.Cos(Game.UpdateTime.Total.TotalSeconds));
        }
    }
}
