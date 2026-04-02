using Gamer.Player;
using Raylib_cs;
using System.ComponentModel;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Gamer.World
{
    internal class Hitbox
    {
        public bool IsHited = false;
        public bool soundPlayed = false;
        Sound sound;
        public Hitbox(Sound sound)
        {
            this.sound = sound;
        }
        public void Update(float deltaTime, Spawner spawner, Duck duck)
        {
            foreach (var car in spawner.cars)
            {
                if (!soundPlayed && Raylib.CheckCollisionRecs(duck.GetHitbox, car.GetHitbox))
                {
                    Raylib.PlaySound(sound);
                    soundPlayed = true;
                }
                car.Update(deltaTime);
                if (Raylib.CheckCollisionRecs(duck.GetHitbox, car.GetHitbox))
                {
                    IsHited = true;
                }
            }
        }
        public void Unload()
        {
            Raylib.UnloadSound(sound);
        }
    }
}
