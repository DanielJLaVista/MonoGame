using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class World {
        public Vector2 offset;
        public Hero hero;
        public List<Projectile2d> projectiles = new List<Projectile2d> ();
        public List<Mob> mobs = new List<Mob> ();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint> ();
        public int numKilled;
        public UI ui;
        PassObject ResetWorld;
        public World(PassObject ResetWorld) {
            this.ResetWorld = ResetWorld;
            numKilled = 0;
            hero = new Hero ("2d/Units/Hero", new Vector2 (300, 300), new Vector2 (48, 48));

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMob;
            GameGlobals.CheckScroll = CheckScroll;
            offset = new Vector2 (0, 0);

            spawnPoints.Add (new SpawnPoint ("2d/Misc/circle", new Vector2 (50, 50), new Vector2 (35, 35)));
            spawnPoints.Add (new SpawnPoint ("2d/Misc/circle", new Vector2 (Globals.screenWidth / 2, 50), new Vector2 (35, 35)));
            spawnPoints.Last ().spawnTimer.AddTime (500);
            spawnPoints.Add (new SpawnPoint ("2d/Misc/circle", new Vector2 (Globals.screenWidth - 50, 50), new Vector2 (35, 35)));
            spawnPoints.Last ().spawnTimer.AddTime (1000);
            ui = new UI ();
        }

        public virtual void Update() {
            hero.Update (offset);
            if (!hero.dead) {
                for (int i = 0; i < spawnPoints.Count; i++) {
                    spawnPoints[i].Update (offset);
                }
                for (int i = 0; i < projectiles.Count; i++) {
                    projectiles[i].Update (offset, mobs.ToList<Unit> ());
                    if (projectiles[i].done) {
                        projectiles.RemoveAt (i);
                        i--;
                    }
                }
                for (int i = 0; i < mobs.Count; i++) {
                    mobs[i].Update (offset, hero);
                    if (mobs[i].dead) {
                        numKilled++;
                        mobs.RemoveAt (i);
                        i--;
                    }
                }
            } else {
                if (Globals.keyboard.GetPress ("Enter")) {
                    ResetWorld (null);
                }
            }
            ui.Update (this);
        }

        public virtual void AddMob(object info) {
            mobs.Add ((Mob)info);
        }
        public virtual void AddProjectile(object info) {
            projectiles.Add ((Projectile2d)info);
        }
        public virtual void CheckScroll(Object info) {
            Vector2 tempPos = (Vector2)info;
            if (tempPos.X < -offset.X + (Globals.screenWidth * 0.4f)) {
                offset = new Vector2 (offset.X + hero.speed * 2, offset.Y);
            }
            if (tempPos.X > -offset.X + (Globals.screenWidth * 0.6f)) {
                offset = new Vector2 (offset.X - hero.speed * 2, offset.Y);
            }
            if (tempPos.Y < -offset.Y + (Globals.screenHeight * 0.4f)) {
                offset = new Vector2 (offset.X, offset.Y + hero.speed * 2);
            }
            if (tempPos.Y > -offset.Y + (Globals.screenHeight * 0.6f)) {
                offset = new Vector2 (offset.X, offset.Y - hero.speed * 2);
            }
        }
        public virtual void Draw(Vector2 offset) {
            hero.Draw (this.offset);
            for (int i = 0; i < spawnPoints.Count; i++) {
                spawnPoints[i].Draw (this.offset);
            }
            for (int i = 0; i < projectiles.Count; i++) {
                projectiles[i].Draw (this.offset);
            }
            for (int i = 0; i < mobs.Count; i++) {
                mobs[i].Draw (this.offset);

            }
            ui.Draw (this);
        }
    }
}