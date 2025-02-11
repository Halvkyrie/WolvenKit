using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class questGameManagerNodeDefinition : questTypedSignalStoppingNodeDefinition
	{
		[Ordinal(2)] 
		[RED("type")] 
		public CHandle<questIGameManagerNodeType> Type
		{
			get => GetPropertyValue<CHandle<questIGameManagerNodeType>>();
			set => SetPropertyValue<CHandle<questIGameManagerNodeType>>(value);
		}

		public questGameManagerNodeDefinition()
		{
			Sockets = new();
			Id = 65535;
		}
	}
}
