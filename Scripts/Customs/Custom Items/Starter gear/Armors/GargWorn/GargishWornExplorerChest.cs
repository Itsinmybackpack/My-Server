using System;
using Server.Items;

namespace Server.Items
{
	[Flipable]
	public class GargishWornExplorerChest : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 2; } }
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 3; } }
		public override int BasePoisonResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 3; } }

		public override int InitMinHits{ get{ return 20; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override int AosStrReq{ get{ return 25; } }
		public override int OldStrReq{ get{ return 15; } }

		public override int ArmorBase{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }
		
		public override bool CanBeWornByGargoyles{ get{ return true; } }
		
		public override Race RequiredRace{ get { return Race.Gargoyle; } }


		[Constructable]
		public GargishWornExplorerChest() : base( 0x0304 )
		{
            Name = "Worn Explorer Chest";
            Hue = 1159;
            Attributes.LowerRegCost = 20;
			Weight = 6.0;
		}

        public GargishWornExplorerChest(Serial serial)
            : base(serial)
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( Weight == 1.0 )
				Weight = 6.0;
		}
	}
}