namespace Fox
{
	public class KernelModule : Module
	{
		public static KernelModule Instance { get; private set; }

		public KernelModule() : base("Fox.Kernel")
		{
			Instance = this;
		}
	}
}