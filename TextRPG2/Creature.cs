using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG2
{
    public enum CreatureType
    {
        None,
        Player = 1,
        Monster = 2
    }
    class Creature
    {
        CreatureType type;

        protected int hp = 0;
        protected int att = 0;
        protected Creature(CreatureType type)
        {
            this.type = type;
        }

        public void SetInfo(int hp, int att)
        {
            this.hp = hp;
            this.att = att;

        }

        public int GetHp() { return hp; }
        public int GetAtt() { return att; }
        public bool IsDead() { return hp <= 0; }
        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;
        }
    }
}
