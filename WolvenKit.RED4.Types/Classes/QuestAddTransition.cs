using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class QuestAddTransition : redEvent
	{
		[Ordinal(0)] 
		[RED("transition")] 
		public AreaTypeTransition Transition
		{
			get => GetPropertyValue<AreaTypeTransition>();
			set => SetPropertyValue<AreaTypeTransition>(value);
		}

		public QuestAddTransition()
		{
			Transition = new();
		}
	}
}
