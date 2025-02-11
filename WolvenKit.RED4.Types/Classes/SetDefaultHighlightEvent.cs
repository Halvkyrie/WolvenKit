using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class SetDefaultHighlightEvent : redEvent
	{
		[Ordinal(0)] 
		[RED("highlightData")] 
		public CHandle<HighlightEditableData> HighlightData
		{
			get => GetPropertyValue<CHandle<HighlightEditableData>>();
			set => SetPropertyValue<CHandle<HighlightEditableData>>(value);
		}
	}
}
