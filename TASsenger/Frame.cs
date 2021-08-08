using System;

namespace TASsenger
{
    public struct Frame
    {
        public bool Up;
        public bool Down;
        public float Ver => Up ? 1f : (Down ? -1f : 0f);

        public bool Left;
        public bool Right;
        public float Hor => Right ? 1f : (Left ? -1f : 0f);

        public bool Attack;
        public bool Jump;
        public bool Rope;
        public bool Shuriken;
        public bool Tabi;

        public bool Interact;
        public bool Inventory;
        public bool Map;

        public bool Start;

        public bool Back;
        public bool Cancel;
        public bool Confirm;
    }
}
