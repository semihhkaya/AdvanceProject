namespace AdvanceProject.Core.Result
{
	public class SuccessResult : Result
    {   
        public SuccessResult(string message) : base(true, message) //Base burda Result class'ına gidiyor.
        {

        }

        public SuccessResult() : base(true)
        {

        }
    }
}
