using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace HashMethods.WEB.Pages
{
    public class Sha1Model : PageModel
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

            ComputeSha1();

            return Page();
        }

        public IActionResult OnPostReset()
        {
            CleareVariables();

            return Page();
        }

        #region privateMethods
        private string ComputeSha1()
        {
            HashAlgorithm sha1 = SHA1.Create();

            byte[] byteResult = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(RawString));

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
