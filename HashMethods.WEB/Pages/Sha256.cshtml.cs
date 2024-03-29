using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace HashMethods.WEB.Pages
{
    public class Sha256Model : PageModel
    {
        #region bindProperty(ies)

        [BindProperty]
        public string Result { get; set; }

        [BindProperty]
        public string RawString { get; set; }

        #endregion
        public void OnGet()
        {
            CleareVariables();
        }

        public IActionResult OnPostCompute()
        {
            string Result = string.Empty;

            ComputeSha256();

            return Page();
        }

        public IActionResult OnPostReset()
        {
            CleareVariables();

            return Page();
        }

        #region privateMethods
        private string ComputeSha256()
        {
            HashAlgorithm sha256 = SHA256.Create();

            byte[] byteResult = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(RawString));

            Result = Convert.ToBase64String(byteResult);

            return Result;
        }

        private void CleareVariables()
        {
            Result = string.Empty;

            RawString = string.Empty;

            ModelState.Clear();
        }

        #endregion
    }
}
