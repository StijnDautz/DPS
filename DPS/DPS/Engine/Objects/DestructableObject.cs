namespace Engine
{
    class DestructableObject : TexturedObject
    {
        int health = 1;
        string type;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public DestructableObject(string id, Object parent, SpriteSheet spriteSheet) : base(id, parent, spriteSheet)
        {

        }
    }
}