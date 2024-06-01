using _Project.Code.Runtime.Data;

namespace _Project.Code.Runtime.Services.SaveLoadService
{
    public interface ISaveLoadService
    {
        public void Save(PlayerProgress playerProgress);
        public PlayerProgress Load();
        public void Reset();
    }
}