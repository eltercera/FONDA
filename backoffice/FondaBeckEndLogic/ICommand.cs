using System;

namespace com.ds201625.fonda.BackEndLogic
{
	public interface ICommand
	{

		void Run();

		void SetParameter (int index, Object data);

		Object Result
		{
			get;
		}
	}
}

