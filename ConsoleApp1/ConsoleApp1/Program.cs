namespace ConsoleApp1
{
    class Weapon
    {
        public string Name { get; private set; }

        public int Damage { get; private set; }

        public int Bullets { get; private set; }

        public Weapon(string name, int damage, int bullets)
        {
            Name = name;
            Damage = damage;
            Bullets = bullets;
        }

        public void Fire(Player player)
        {
            if (Bullets <= 0 || Damage < 0)
                return;

            player.TakeDamage(Damage);
            Bullets--;
        }
    }

    class Player
    {
        public PlayerHealth PlayerHealth { get; private set; }

        public Player(int value)
        {
            PlayerHealth = new PlayerHealth(value);
        }

        public void TakeDamage(int value)
        {
            PlayerHealth.TakeDamage(value);
        }
    }

    abstract class Health
    {
        private int _hp;

        public int HP
        {
            get { return _hp; }
            protected set
            {
                if (value > 0)
                    _hp = Math.Max(0, value);
            }
        }
    }

    interface IDamageable
    {
        void TakeDamage(int value);
    }

    class PlayerHealth : Health, IDamageable
    {
        public PlayerHealth(int health)
        {
            HP = health;
        }

        public void TakeDamage(int value)
        {
            if (HP > 0)
                HP -= value;
            else
                Console.WriteLine("Player is already dead");
        }
    }

    class EnemyHealth : Health, IDamageable
    {
        public EnemyHealth(int health)
        {
            HP = health;
        }

        public void TakeDamage(int value)
        {
            if (HP > 0)
                HP -= value;
            else
                Console.WriteLine("Player is already dead");
        }
    }

    class Bot
    {
        public EnemyHealth EnemyHealth { get; private set; }

        public Weapon Weapon { get; private set; }

        public Bot(Weapon weapon, EnemyHealth enemyHealth)
        {
            Weapon = weapon;
            EnemyHealth = enemyHealth;
        }

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }
}