using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class worldRoadMaterialInfo : CVariable
	{
		[Ordinal(0)]  [RED("material")] public CEnum<worldRoadMaterial> Material { get; set; }
		[Ordinal(1)]  [RED("startOffset")] public CFloat StartOffset { get; set; }

		public worldRoadMaterialInfo(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}