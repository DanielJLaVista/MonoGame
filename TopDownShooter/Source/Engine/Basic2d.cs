using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter.Source.Engine
{
    public class Basic2d
    {
        public Vector2 pos, dims;
        public Texture2D model;
        public Basic2d(string path,Vector2 pos, Vector2 dims){
this.pos=pos;
this.dims=dims;
model=Globals.content.Load<Texture2D>(path);
        }

        public virtual void Update(){

        }

        public virtual void Draw(){

        }
    }
}