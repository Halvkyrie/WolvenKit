using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class questValueDistance : questIDistance
	{
		[Ordinal(0)] 
		[RED("distanceValue")] 
		public CFloat DistanceValue
		{
			get => GetPropertyValue<CFloat>();
			set => SetPropertyValue<CFloat>(value);
		}
	}
}
