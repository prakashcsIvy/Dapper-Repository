using System;
using System.Collections.Generic;
using System.Text;

namespace DWC.Models.Models
{
    public class SADM_Users
    {
        public long SU_Id { get; set; }
        public int? SU_Principal_Id { get; set; }
        public string SU_User_Type { get; set; }
        public string SU_User_Code { get; set; }
        public string SU_First_Name { get; set; }
        public string SU_Middle_Name { get; set; }
        public string SU_Last_Name { get; set; }
        public string SU_Gender { get; set; }
        public DateTime? SU_DOB { get; set; }
        public DateTime? SU_DOJ { get; set; }
        public short? SU_SUL_Id { get; set; }
        public int? SU_SR_Id { get; set; }
        public int? SU_Company_Id { get; set; }
        public string SU_Address { get; set; }
        public string SU_Mobile_No { get; set; }
        public string SU_Email_Id { get; set; }
        public bool SU_Isactive { get; set; }
        public DateTime SU_Activated_Date { get; set; }
        public DateTime? Su_DeActivated_Date { get; set; }
        public long SU_Created_By { get; set; }
        public DateTime SU_Created_Date { get; set; }
        public long? SU_Modified_By { get; set; }
        public DateTime? SU_Modified_Date { get; set; }
        public string SU_Login_Id { get; set; }
        public string SU_Password { get; set; }
        public int? SU_Login_Attempt { get; set; }
        public DateTime? SU_Login_Time { get; set; }
        public DateTime? SU_Password_Modified_Date { get; set; }
        public string SU_Otp { get; set; }
        public DateTime? SU_Otp_Valid_From { get; set; }
        public DateTime? SU_Otp_Valid_To { get; set; }
        public long? SU_Otp_Generated_By { get; set; }
        public DateTime? SU_Otp_Generated_Date { get; set; }
        public bool? SU_Otp_IsUsed { get; set; }
        public string SU_GCM_RegistrationId { get; set; }
        public bool? SU_IsReset_Password { get; set; }
        public bool? SU_IsMobileVerified { get; set; }
        public string SU_Device_Id { get; set; }
        public long SU_Parent_Id { get; set; }
        public short SU_Language_Id { get; set; }
        public string SU_Status { get; set; }
        public bool? SU_IsEmailVerified { get; set; }

    }
}
