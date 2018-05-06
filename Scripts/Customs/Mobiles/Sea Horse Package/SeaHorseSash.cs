using System;
using Server;

namespace Server.Items
{
	public class SeaHorseSash : BodySash
	{
		

		[Constructable]
		public SeaHorseSash()
		{
			Hue = 1266;
                        Name = "Sash of the Sea Horse";
			
			Attributes.Luck = 150;
		}

		public SeaHorseSash( Serial serial ) : base( serial )
		{
		}
		public override void OnAdded( IEntity parent )
		{
			base.OnAdded( parent );

			if ( parent is Mobile )
			{
				((Mobile)parent).CanSwim = true;
			}
		}

		public override void OnRemoved( IEntity parent )
		{
			base.OnRemoved( parent );

			if ( parent is Mobile )
			{
				((Mobile)parent).CanSwim = false;
			}
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

			
		}
	}
}