using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	[REDMeta]
	public partial class entRagdollApplyImpulseEvent : redEvent
	{
		[Ordinal(0)] 
		[RED("worldImpulsePos")] 
		public Vector4 WorldImpulsePos
		{
			get => GetPropertyValue<Vector4>();
			set => SetPropertyValue<Vector4>(value);
		}

		[Ordinal(1)] 
		[RED("worldImpulseValue")] 
		public Vector4 WorldImpulseValue
		{
			get => GetPropertyValue<Vector4>();
			set => SetPropertyValue<Vector4>(value);
		}

		[Ordinal(2)] 
		[RED("influenceRadius")] 
		public CFloat InfluenceRadius
		{
			get => GetPropertyValue<CFloat>();
			set => SetPropertyValue<CFloat>(value);
		}

		public entRagdollApplyImpulseEvent()
		{
			WorldImpulsePos = new() { W = 1.000000F };
			WorldImpulseValue = new() { W = 1.000000F };
		}
	}
}
