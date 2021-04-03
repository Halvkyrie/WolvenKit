using WolvenKit.RED4.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED4.CR2W.Types.Enums;

namespace WolvenKit.RED4.CR2W.Types
{
	[REDMeta]
	public class animAnimNodeSourceChannel_TransformVector : animIAnimNodeSourceChannel_Vector
	{
		private animTransformIndex _transformIndex;

		[Ordinal(0)] 
		[RED("transformIndex")] 
		public animTransformIndex TransformIndex
		{
			get => GetProperty(ref _transformIndex);
			set => SetProperty(ref _transformIndex, value);
		}

		public animAnimNodeSourceChannel_TransformVector(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}