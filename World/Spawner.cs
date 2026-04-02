using Gamer.Player;
using Raylib_cs;
using System.Security.Cryptography.X509Certificates;
namespace Gamer.World
{
    internal class Spawner
    {

        public List<Enemy> cars = new List<Enemy>();
        public float[] spawnPositionsY = { 653f, 608f, 518f, 473f, 383f, 293f, 203f, 158f, 68f };
        float spawnTimer = 0f;
        float spawnInterval = 0.3f;
        float y;
        int index;
        Texture2D texture;
        Random random = new();
        public Spawner(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update(float deltaTime, Duck duck)
        {
            spawnTimer += deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
            cars.RemoveAll(e => e.Pos.X > 1311 ||e.Pos.X < -31);
        }
        public void SpawnEnemy()
        {
            index = random.Next(spawnPositionsY.Length);
            y = spawnPositionsY[index];
            cars.Add(new Enemy(texture, y, index));
        }
        public void Draw()
        {
            foreach (var car in cars)
            {
                    car.Draw();
            }
           
        }
    }
}
