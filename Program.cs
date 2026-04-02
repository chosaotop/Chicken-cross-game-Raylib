using Gamer.World;
using Gamer.Player;
using Raylib_cs;
using System.Threading.Channels;

namespace Gamermax
{
    class Program()
    {
        public static void Main()
        {
            Raylib.InitWindow(1280, 720, "pato?");
            Raylib.InitAudioDevice();
            Sound sound = Raylib.LoadSound("assets/metalpipe.mp3");
            Raylib.SetExitKey(KeyboardKey.Null);
            Texture2D eTex = Raylib.LoadTexture("assets/car.png");
            GameRule rule = new();
            Hitbox hitbox = new(sound);
            EndGame end = new();
            Spawner spawn = new(eTex);
            Map map = new();
            Duck player = new();
            Raylib.SetTargetFPS(60);
            while (!Raylib.WindowShouldClose())
            {
                float dt = Raylib.GetFrameTime();
                spawn.Update(dt, player);
                hitbox.Update(dt, spawn, player);
                rule.Update();
                player.Update();
                end.Update(player, spawn, hitbox);
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Gray);
                map.DrawBackGround();
                spawn.Draw();
                player.Draw();
                end.Draw();
                rule.Draw();
                player.Debug();
                Raylib.EndDrawing();
            }
            hitbox.Unload();
            Raylib.CloseAudioDevice();
            player.Unload();
            Raylib.CloseWindow();
        }
    }
}

