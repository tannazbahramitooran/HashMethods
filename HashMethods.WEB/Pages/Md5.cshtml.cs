using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace HashMethods.WEB.Pages
{
    public class Md5Model : PageModel
    {
        #region bindProperty(ies)

        [BindProperty]
        public string Result { get; set; }

        [BindProperty]
        public string RawString { get; set; }

        [BindProperty]
        public string Salt { get; set; }

        #endregion

        public void OnGet()
        {
            CleareVariables();
        }

        public IActionResult OnPostCompute()
        {
            string Result = string.Empty;

            ComputeMd5();

            return Page();
        }

        public IActionResult OnPostReset()
        {
            CleareVariables();

            return Page();
        }

        #region privateMethods
        private string ComputeMd5()
        {
            List<byte> rawStringWithSaltByte = new List<byte>();

            MD5 md5 = MD5.Create();

            byte[] rawStringByte = System.Text.Encoding.UTF8.GetBytes(RawString);

            if (!string.IsNullOrEmpty(Salt))
            {
                byte[] saltByte = System.Text.Encoding.UTF8.GetBytes(Salt);

                rawStringWithSaltByte.AddRange(saltByte);
            }

            rawStringWithSaltByte.AddRange(rawStringByte);

            byte[] byteResult = md5.ComputeHash(rawStringWithSaltByte.ToArray());

            Result = Convert.ToBase64String(byteResult);

            return Result;
        }

        private void CleareVariables()
        {
            Result = string.Empty;

            RawString = string.Empty;

            Salt = string.Empty;

            ModelState.Clear();
        }

        #endregion

    }
}
