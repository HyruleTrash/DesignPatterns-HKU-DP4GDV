namespace LucasCustomClasses
{
    public interface IPoolable
    {
        public bool active { get; set; }
        public void OnEnableObject();
        public void OnDisableObject();
        public void DoDie();
        public IPoolable Instantiate();
    }
}