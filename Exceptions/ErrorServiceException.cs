using Microsoft.AspNetCore.Mvc;

namespace WashApi.Exceptions
{
    public class ErrorServiceException : Exception
    {
        private readonly Func<ControllerBase, IActionResult> _resultFactory;

        public ErrorServiceException(string message, Func<ControllerBase, IActionResult> resultFactory)
            : base(message)
        {
            _resultFactory = resultFactory;
        }

        public IActionResult ToActionResult(ControllerBase controller)
        {
            return _resultFactory(controller);
        }
    }
}
