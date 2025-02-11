using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class AnimFeature_PlayerDeathAnimation : animAnimFeature
	{
		[Ordinal(0)] 
		[RED("animation")] 
		public CInt32 Animation
		{
			get => GetPropertyValue<CInt32>();
			set => SetPropertyValue<CInt32>(value);
		}
	}
}
