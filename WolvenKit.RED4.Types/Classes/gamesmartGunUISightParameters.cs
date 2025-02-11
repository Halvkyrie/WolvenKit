using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class gamesmartGunUISightParameters : RedBaseClass
	{
		[Ordinal(0)] 
		[RED("center")] 
		public Vector2 Center
		{
			get => GetPropertyValue<Vector2>();
			set => SetPropertyValue<Vector2>(value);
		}

		[Ordinal(1)] 
		[RED("targetableRegionSize")] 
		public Vector2 TargetableRegionSize
		{
			get => GetPropertyValue<Vector2>();
			set => SetPropertyValue<Vector2>(value);
		}

		[Ordinal(2)] 
		[RED("reticleSize")] 
		public Vector2 ReticleSize
		{
			get => GetPropertyValue<Vector2>();
			set => SetPropertyValue<Vector2>(value);
		}

		public gamesmartGunUISightParameters()
		{
			Center = new();
			TargetableRegionSize = new();
			ReticleSize = new();
		}
	}
}
