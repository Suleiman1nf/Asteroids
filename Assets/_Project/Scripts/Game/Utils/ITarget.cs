namespace Suli.Asteroids
{
    public enum Target
    {
        Enemy,
        Player,
    }
    public interface ITarget
    {
        public Target Target { get; set; }

        public void DestroySelf();
    }
}