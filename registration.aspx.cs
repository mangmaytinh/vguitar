#region XD World Lyric V 2.8
// FileName: registration.cs
// Author: Dexter Zafra
// Date Created: 2/14/2009
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.BL.Providers;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;
using VGuitar.Security;

public partial class registration : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] Countries = Utility.CountriesList;

        foreach (string country in Countries)
        {
            Country.Items.Add(country);
        }

        HideFormIfLogin.Visible = true;

        //Check whether user is login, if login, hide the registration form.
        //We don't want to allow users who are logon to register.
        //if they want to regsiter a new a count, they must logout first.
        if (Authentication.IsUserAuthenticated)
        {
            HideFormIfLogin.Visible = false;
            lblWarningMessage.Visible = true;
            lblWarningMessage.Text = "Xin lỗi! Bạn không thể đăng ký một tài khoản mới khi bạn đang đăng nhập <br> Nếu bạn muốn đăng ký tài khoản mới., Bạn phải đăng xuất trước.";
        }
    }

    public void Add_User(object s, EventArgs e)
    {
        Utility Util = new Utility();

        if (!Page.IsValid)
        {
            UserRepository User = new UserRepository();

            User.Username = Util.FormatTextForInput(Request.Form[Username.UniqueID]);
            User.Password = Encryption.Encrypt(Util.FormatTextForInput(Request.Form[Password1.UniqueID]));
            User.Email = Util.FormatTextForInput(Request.Form[Email.UniqueID]);
            User.FirstName = Util.FormatTextForInput(Request.Form[Firstname.UniqueID]);
            User.LastName = Util.FormatTextForInput(Request.Form[Lastname.UniqueID]);
            User.City = Util.FormatTextForInput(Request.Form[City.UniqueID]);
            User.State = Util.FormatTextForInput(Request.Form[State.UniqueID]);
            User.Country = Util.FormatTextForInput(Request.Form[Country.UniqueID]);
            User.DOB = DateTime.Parse(Date1.CalendarDateString);
            User.FavoriteFoods1 = Util.FormatTextForInput(Request.Form[FavoriteFoods1.UniqueID]);
            User.FavoriteFoods2 = Util.FormatTextForInput(Request.Form[FavoriteFoods2.UniqueID]);
            User.FavoriteFoods3 = Util.FormatTextForInput(Request.Form[FavoriteFoods3.UniqueID]);
            User.NewsLetter = Int32.Parse(Util.FormatTextForInput(Request.Form[Newsletter.UniqueID]));
            User.ContactMe = Int32.Parse(Util.FormatTextForInput(Request.Form[ContactMe.UniqueID]));
            User.Website = Util.FormatTextForInput(Request.Form[Website.UniqueID]);
            User.AboutMe = Util.FormatTextForInput(Request.Form[AboutMe.UniqueID]);
            User.GUID = Guid.NewGuid().ToString("N");

            //Prevent username and email duplication. Ensure that all username and email in the database are unique.
            //This initialize the value.
            UserNameAndEmailValidation.Param(User.Username, User.Email);

            #region Form Input Validation
            //Handles validation of username and email. This prevent duplication.
            if (!UserNameAndEmailValidation.IsValid)
            {
                lbvalenght.Text = UserNameAndEmailValidation.ErrMsg;
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            if (!Validator.IsAlphaNumericOnly(User.Username))
            {
                lbvalenght.Text = "<br> Lỗi: Tên đăng nhập phải có ít nhất 6 ký tự và lớn nhất 15 ký tự, và chỉ nên chứa chữ số. ";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            //Let's decrypt the password for validation.
            if (!Validator.IsAlphaNumericOnly(Encryption.Decrypt(User.Password)))
            {
                lbvalenght.Text = "<br> Lỗi: Mật khẩu phải có ít nhất 6 ký tự và lớn nhất 12 ký tự, và chỉ nên chứa chữ số.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            //Let's decrypt the password for validation.
            if (Util.FormatTextForInput(Request.Form[Password1.UniqueID]) != Util.FormatTextForInput(Request.Form[Password2.UniqueID]))
            {
                lbvalenght.Text = "<br> Lỗi: Mật khẩu không giống nhau. Vui lòng. nhập một mật khẩu và đảm bảo rằng chúng phù hợp cả hai.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            if (!Validator.IsValidEmail(User.Email))
            {
                lbvalenght.Text = "<br> Lỗi: Địa chỉ Email không hợp lệ. Địa chỉ email. phải là một định dạng hợp lệ.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            if (!Validator.IsValidName(User.FirstName))
            {
                lbvalenght.Text = "<br> Lỗi: Tên của bạn nên được bảng chữ cái và không chứa các ký tự bất hợp pháp.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            if (!Validator.IsValidName(User.LastName))
            {
                lbvalenght.Text = "<br> Lỗi: Tên họ và tên đệm của bạn nên được bảng chữ cái và không chứa các ký tự bất hợp pháp.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            if (User.FavoriteFoods1.Length > 25)
            {
                lbvalenght.Text = "<br> Lỗi: Bài hát yêu thích 1 là quá dài, tối đa là 25 ký tự..";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            if (User.FavoriteFoods2.Length > 25)
            {
                lbvalenght.Text = "<br> Lỗi: Bài hát yêu thích 2 là quá dài, tối đa là 25 ký tự..";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            if (User.FavoriteFoods3.Length > 25)
            {
                lbvalenght.Text = "<br> Lỗi: Bài hát yêu thích 3 là quá dài, tối đa là 25 ký tự..";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            if (User.Country == "none")
            {
                lbvalenght.Text = "<br> Lỗi: Bạn phải chọn một quốc gia.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            if (User.AboutMe.Length > 500)
            {
                lbvalenght.Text = "<br> Lỗi: Văn bản giới thiệu về bản thân quá dài. tối đa là 500 ký tự.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            if (User.Website.Length > 75)
            {
                lbvalenght.Text = "<br> Lỗi: Địa chỉ website quá dài tối đa là 75 ký tự..";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";
                return;
            }

            #endregion

            if (UserImageFileUpload.HasFile)
            {
                int FileSize = UserImageFileUpload.PostedFile.ContentLength;
                string contentType = UserImageFileUpload.PostedFile.ContentType;

                //File type validation
                if (!contentType.Equals("image/gif") &&
                    !contentType.Equals("image/jpeg") &&
                    !contentType.Equals("image/jpg") &&
                    !contentType.Equals("image/png"))
                {
                    lbvalenght.Text = "<br>Ảnh của bạn không đúng định dạng. chỉ cho phép những định dạng sau gif, jpg, jpeg or png.";
                    lbvalenght.Visible = true;
                    return;
                }
                // File size validation
                if (FileSize > constant.UserImageMaxSize)
                {
                    lbvalenght.Text = "<br> Dung lượng vượt quá 60.000 byte cho phép";
                    lbvalenght.Visible = true;
                    return;

                }
            }

            ImageUploadManager.UploadUserImage(User, PlaceHolder1, GetUserImage.ImagePathForUserPhoto, constant.UserImageMaxSize);

            if (User.Add(User) != 0)
            {
                JSLiteral.Text = "Có lỗi sảy ra trong quá trình sử lý yêu cầu của bạn.";
                return;
            }

            EmailAccountActivationLink(User);

            User = null;

            Response.Redirect("redirectionpage.aspx?email=" + Request.Form[Email.UniqueID]);
        }
        else
        {
            JSLiteral.Text = Util.JSAlert("Mã bảo mật không hợp lệ. Hãy chắc chắn rằng bạn nhập chính xác.");
            return;

            lblinvalidsecode.Text = "Mã bảo mât không đúng. Hãy chắc chắn bạn đã nhập đúng các ký tự của mã bảo vệ.";
            lblinvalidsecode.Visible = true;
        }

        Util = null;
    }

    private void EmailAccountActivationLink(UserRepository User)
    {
        EmailTemplate SendeMail = new EmailTemplate();
        SendeMail.LyricEmail = User.Email;
        SendeMail.SendActivationLink(User.Username, User.GUID);
        SendeMail = null;
    }
}
