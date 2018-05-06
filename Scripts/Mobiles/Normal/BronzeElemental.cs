using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an ore elemental corpse")]
    public class BronzeElemental : BaseCreature
    {
        [Constructable]
        public BronzeElemental()
            : this(25)
        {
        }

        [Constructable]
        public BronzeElemental(int oreAmount)
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            // TODO: Gas attack
            this.Name = "a bronze elemental";
            this.Body = 108;
            this.BaseSoundID = 268;

            this.SetStr(226, 255);
            this.SetDex(126, 145);
            this.SetInt(71, 92);

            this.SetHits(136, 153);

            this.SetDamage(9, 16);

            this.SetDamageType(ResistanceType.Physical, 30);
            this.SetDamageType(ResistanceType.Fire, 70);

            this.SetResistance(ResistanceType.Physical, 30, 40);
            this.SetResistance(ResistanceType.Fire, 30, 40);
            this.SetResistance(ResistanceType.Cold, 10, 20);
            this.SetResistance(ResistanceType.Poison, 70, 80);
            this.SetResistance(ResistanceType.Energy, 20, 30);

            this.SetSkill(SkillName.MagicResist, 50.1, 95.0);
            this.SetSkill(SkillName.Tactics, 60.1, 100.0);
            this.SetSkill(SkillName.Wrestling, 60.1, 100.0);

            this.Fame = 5000;
            this.Karma = -5000;

            this.VirtualArmor = 29;

            Item ore = new BronzeOre(oreAmount);
            ore.ItemID = 0x19B9;
            this.PackItem(ore);
        }

        public BronzeElemental(Serial serial)
            : base(serial)
        {
        }

        public override bool BleedImmune
        {
            get
            {
                return true;
            }
        }
        public override bool AutoDispel
        {
            get
            {
                return true;
            }
        }
        public override int TreasureMapLevel
        {
            get
            {
                return 1;
            }
        }
        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Average);
            this.AddLoot(LootPack.Gems, 2);
        }

        public override void OnDeath( Container c )
	{
		base.OnDeath( c );

                if (Utility.RandomDouble() < 0.5)
                    c.DropItem(new RunicHammer( CraftResource.Bronze, 50 ) );
 	}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
