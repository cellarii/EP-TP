using EP.Objects;
using EP.Objects;
using System.DirectoryServices.ActiveDirectory;
using System.Net.Http.Headers;

namespace EP
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new();
        Player player;
        Marker marker;
        Random random = new Random();
        int bonusCount = 0;
        public Form1()
        {
            InitializeComponent();
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            player.OnEnemyOverlap += (en) =>
            {
                objects.Remove(en);
                bonusCount += 1;
                txtBonus.Text = "Очки: " + bonusCount;
                createEnemy();
            };
            createEnemy();
            createEnemy();
            objects.Add(player);
            txtBonus.Text = "Очки: " + bonusCount;
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            updatePlayer();
            foreach(var en in objects.OfType<Enemy>())
            {
                en.ReduceSize();
            }

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.overlaps(obj, g))
                {
                    player.OverLap(obj);
                    obj.OverLap(player);
                }
            }

            foreach (var obj in objects)
            {
                g.Transform = obj.getTransform();
                obj.Render(g);
            }
        }

        private void updatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                float length = (float)Math.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;

                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }

            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;

            player.X += player.vX;
            player.Y += player.vY;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updatePlayer();
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }
            marker.X = e.X;
            marker.Y = e.Y;
        }

        public void createEnemy()
        {
            var enemy = new Enemy(random.Next(15, pbMain.Width - 16), random.Next(15, pbMain.Height - 16), 0);
            enemy.EnemyDisappeared += (en) =>
            {
                var x = random.Next(50, pbMain.Width - 50);
                var y = random.Next(50, pbMain.Height - 50);
                en.respawn(x, y);
                bonusCount -= 1;
                txtBonus.Text = "Очки: " + bonusCount;
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Враг исчез" + txtLog.Text;
            };
            objects.Add(enemy);
        }
    }
}