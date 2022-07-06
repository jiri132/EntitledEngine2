namespace EntitledEngine2.Engine.Core.ECS
{
    public static class Destructor 
    {
        public static void Destruct(Entity e) { Engine.UnRegisterEntity(e); }
    }
}
