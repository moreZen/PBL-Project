namespace WebApplication2017_MVC_GuestBook.Models2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;     // �C�����W�誺 [ ]�Ÿ��A�N�o�f�t�o�өR�W�Ŷ�
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserTable2
    {
        [Key]    // �D������]P.K.�^
        public int UserId { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "�W�١]UserName�^")]
        [Required (ErrorMessage = "*** �ۭq�T�� *** ������� ***")]     // �������
        public string UserName { get; set; }


        [StringLength(1)]
        [Display(Name = "�ʧO�]UserSex�^")]
        public string UserSex { get; set; }


        [Display(Name = "�ͤ�]UserBirthDay�^")]
        [DataType(DataType.Date)]    // �u����� - �u�~���v�C�p�G�O DateTime�N�O�u����P�ɶ��v
        // �[�FDataType�A�Шϥ� Chrome�s�������[��C�|�X�{²�檺�u���v���Chttps://stackoverflow.com/questions/12633471/mvc4-datatype-date-editorfor-wont-display-date-value-in-chrome-fine-in-interne
        //************************
        [Range(typeof(DateTime), "1/1/1950", "1/1/2020", ErrorMessage = "����϶��A�u��b1950�~�H��~2020�~���e")]   // �]�w����϶��]��/��/�~�^
        //************************
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]   // �]�w����� yyyy/MM/dd �榡
        public DateTime? UserBirthDay { get; set; }


        [StringLength(15, ErrorMessage = "*** �ۭq�T�� *** ���o�W�L15�ӼƦr ***")]
        [Display(Name = "������X�]UserMobilePhone�^")]
        [RegularExpression(@"^(09)([0-9]{8})$")]   // �e��ӼƦr�����O09�A�᭱��ۤK�ӼƦr�][0-9] �����O0~9���Ʀr�^�C
        // ���W�B�⦡�B���W��F���]regular expression�^�C  ^�Ÿ� �N��}�l�A$�Ÿ� �N�����C
        [Required]     // �������
        public string UserMobilePhone { get; set; }

        
        //***** �s�W����ƪ����]���O���ݩʡ^ ******************************
        [Display(Name = "�b���w�ҥΡH�]UserApproved�^")]
        public bool UserApproved { get; set; }


        public int? DepartmentId { get; set; }


        //*************************************************************************
        //*** �����ݩʡ]navigation property.�^***
        // https://docs.microsoft.com/zh-tw/dotnet/framework/data/adonet/ef/language-reference/query-expression-syntax-examples-navigating-relationships

        public virtual DepartmentTable2 DepartmentTable2s { get; set; }   // �`�N�I�᭱�O�Ƽơ]s�^
        // (1) virtual���ηN�H�H
        // ���G Navigation properties are typically defined as "virtual" 
        //         so that they can take advantage of certain Entity Framework functionality such as "lazy loading". 
    }
}
