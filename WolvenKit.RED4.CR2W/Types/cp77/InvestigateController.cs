using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class InvestigateController : AIbehaviorconditionScript
	{
		private stimInvestigateData _investigateData;

		[Ordinal(0)] 
		[RED("investigateData")] 
		public stimInvestigateData InvestigateData
		{
			get => GetProperty(ref _investigateData);
			set => SetProperty(ref _investigateData, value);
		}

		public InvestigateController(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}