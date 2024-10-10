using Microsoft.AspNetCore.Mvc;

namespace StudentInformationSystem.WEBUI.ViewComponents
{
    public class PaymentCreditCardDetailsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // goes to Views/Shared/Components/PaymentCreditCard/Default.cshtml
        }
    }
}
