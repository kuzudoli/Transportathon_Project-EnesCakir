using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Transportathon_Project_EnesCakir.Extensions
{
    public static class ModelStateExtension
    {
        public static void AddModelIdentityError(this ModelStateDictionary modelState, IEnumerable<IdentityError> errors)
        {
            foreach (var err in errors)
                modelState.AddModelError(string.Empty, err.Description);
        }
    }
}
