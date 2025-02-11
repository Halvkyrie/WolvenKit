using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class gameuiCharacterCustomizationSystem_OnOptionUpdatedEvent : redEvent
	{
		[Ordinal(0)] 
		[RED("option")] 
		public CWeakHandle<gameuiCharacterCustomizationOption> Option
		{
			get => GetPropertyValue<CWeakHandle<gameuiCharacterCustomizationOption>>();
			set => SetPropertyValue<CWeakHandle<gameuiCharacterCustomizationOption>>(value);
		}
	}
}
