using Gamer.Player;
using Raylib_cs;
using System.ComponentModel;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Gamer.World
{
    internal class EndGame
    {
        Texture2D tex = Raylib.LoadTexture("assets/galinacio.png");
        Texture2D tex2 = Raylib.LoadTexture("assets/galinacioGO.png");
        bool end;
        bool reset;
        bool gameOver;
        public EndGame()
        {
        }
        public void Update(Duck duck, Spawner spawner, Hitbox hitbox)
        {
            
            if (duck.Pos.Y == 23) 
            {
                end = true;
            }
            if (end)
            {
                duck.Rotation = 0f;
                duck.step = 0f;
                if (Raylib.IsKeyPressed(KeyboardKey.R))
                {
                    end = false;
                   reset = true;
                }
            }
            if (hitbox.IsHited)
            {
                gameOver = true;
                duck.Rotation = 0f;
                duck.tex = tex2;
                duck.step = 0f;
                foreach (var car in spawner.cars)
                {
                    car.Speed = 0f;
                }
            }
                if (reset || Raylib.IsKeyPressed(KeyboardKey.R))
                {
                    gameOver = false;
                    end = false;
                    foreach (var car in spawner.cars)
                    {
                        car.Pos.X = 1330;
                    }
                    duck.tex = tex;
                    duck.Pos = new(630, 698);
                    duck.step = 45f;
                    hitbox.IsHited = false;
                    hitbox.soundPlayed = false;
                    reset = false;
                }
        }
        public void Draw()
        {
            if (gameOver)
            {
                Raylib.DrawRectangle(0, 240, 1280, 240, Color.DarkBrown);
                Raylib.DrawText("GAME OVER!", 490, 300, 50, Color.White);
                Raylib.DrawText("Pressione 'R' para recarregar", 400, 340, 30, Color.White);
            }
            if (end)
            {
                Raylib.DrawRectangle(0, 240, 1280, 240, Color.DarkBlue);
                Raylib.DrawText("VOCE GANHOU!", 450, 300, 50, Color.White);
                Raylib.DrawText("Pressione 'R' para recarregar", 400, 340, 30, Color.White);
                Raylib.DrawText("Pressione 'ESC' para sair", 430, 368, 30, Color.White);
            }
        }

    }
}
