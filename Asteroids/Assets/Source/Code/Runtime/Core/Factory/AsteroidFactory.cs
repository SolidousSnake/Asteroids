using Code.Runtime.Unit;

namespace Code.Runtime.Infrastructure.Factory
{
    public sealed class AsteroidFactory : Factory<Asteroid>
    {
        public AsteroidFactory(Asteroid prefab) : base(prefab)
        {

        }
    }
}
