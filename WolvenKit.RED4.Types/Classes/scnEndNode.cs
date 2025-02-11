using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class scnEndNode : scnSceneGraphNode
	{
		[Ordinal(3)] 
		[RED("type")] 
		public CEnum<scnEndNodeNsType> Type
		{
			get => GetPropertyValue<CEnum<scnEndNodeNsType>>();
			set => SetPropertyValue<CEnum<scnEndNodeNsType>>(value);
		}

		public scnEndNode()
		{
			NodeId = new() { Id = 4294967295 };
			OutputSockets = new();
		}
	}
}
